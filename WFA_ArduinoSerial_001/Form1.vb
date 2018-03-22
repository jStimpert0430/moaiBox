
'SUPERCARD RFID launcher system
'Version 0.1.2 - In Development

'This program is intended to be used in conjunction with an Arduino and RC522 RFID module running custom software in order to launch various shortcuts or webpages using a 1kb RFID card's 4 byte UID as a unique primary key to read and store data in an OleDb structure.
'A simple tutorial program written for Arduino <-> Visual Basic communication authored by Martyn Currey was used as a base for this project and can be found at - "http://www.martyncurrey.com/arduino-and-visual-basic-part-1-receiving-data-from-the-arduino/"

Option Explicit On
'Option Strict On
Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Data.OleDb

Module modConnection
    Public cn As New OleDb.OleDbConnection
    Public cm As New OleDb.OleDbCommand
    Public dr As OleDbDataReader

    Public Sub connection()
        cn = New OleDb.OleDbConnection
        With cn
            .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\cardStorage.mdb"
            .Open()
        End With
    End Sub
End Module

Public Class Form1

    Const VERSION As String = "0.2.0"
    Dim comPORT As String
    Dim receivedData As String = ""
    Dim tempFilename As String
    Dim tempFilePath As String
    Dim validCard As Boolean = False
    Dim arduinoConnected As Boolean = False
    Dim ports As String() = SerialPort.GetPortNames()

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "SUPERCARD RFID Launcher v." + VERSION
        Call connection()
        Timer1.Enabled = False
        comPORT = ""
        autoconnect()
        connect_BTN.PerformClick()

        '
        For Each sp As String In ports 'My.Computer.Ports.SerialPortNames
            'ComPortToolStripMenuItem.DropDownItems.Add(sp)
            'ComPortToolStripMenuItem.DropDownItems.Item
            comPort_ComboBox.Items.Add(sp)
        Next
        'autoDetect()
    End Sub

    'Set current com port to that selected in the combo box when changed
    Private Sub comPort_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comPort_ComboBox.SelectedIndexChanged
        If (CType(comPort_ComboBox.SelectedItem, String) <> "") Then
            comPORT = CType(comPort_ComboBox.SelectedItem, String)
        End If
    End Sub


    Private Sub connect_BTN_Click(sender As Object, e As EventArgs) Handles connect_BTN.Click
        If (connect_BTN.Text = "Connect") Then
            If (comPORT <> "") Then

                'Initialize serialport
                SerialPort1.Close()
                SerialPort1.PortName = comPORT
                SerialPort1.BaudRate = 9600
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.Encoding = System.Text.Encoding.Default 'very important!
                SerialPort1.ReadTimeout = 10000

                'open communication with arduino
                SerialPort1.Open()
                SerialPort1.DiscardInBuffer()
                SerialPort1.DiscardOutBuffer()
                'SerialPort1.Write("aaa")
                connect_BTN.Text = "Dis-connect"
                Timer1.Enabled = True
                Timer_LBL.Text = "Timer: ON"
                lblStatusConnection.Text = "Scanner: OK! Ready to read data.                                SUPERCARD on " + comPORT
                RichTextBox1.Text &= "Connected to scanner... Now listening for cards." & vbCrLf & vbCrLf
            Else
                MsgBox("Select a COM port first")
            End If
        Else

            'Com Disconnect Logic
            SerialPort1.Close()
            connect_BTN.Text = "Connect"
            Timer1.Enabled = False
            Timer_LBL.Text = "Timer: OFF"
            lblStatusConnection.Text = "Scanner: Not Connected"
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Ping for serial data every tick of the timer
        receivedData = ReceiveSerialData()

        'Once a UID of valid length is recieved, loop it through existing cards to see if there is a match
        If receivedData.Length = 12 Then
            validCard = False
            RichTextBox1.Text &= "Card Scanned -- UID: " + receivedData & vbCrLf
            Try
                Call connection()
                cm = New OleDb.OleDbCommand
                With cm
                    .Connection = cn
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT * FROM Table1 WHERE (UID = '" & receivedData & "')"
                    dr = .ExecuteReader
                End With
                While dr.Read()
                    txtSFX.Text = dr("sfxFilePath").ToString
                    If ComPortToolStripMenuItem.Checked Then
                        If (txtSFX.Text = "") Then
                            My.Computer.Audio.Play(My.Resources.kaching, AudioPlayMode.Background) 'TODO: Link this sound effect to a possible user set one, or just use the default
                        Else
                            My.Computer.Audio.Play(txtSFX.Text, AudioPlayMode.Background) 'TODO: Link this sound effect to a possible user set one, or just use the default
                        End If
                    End If
                    txtUID.Text = dr("UID").ToString
                    txtShortcut.Text = dr("shortcutName").ToString
                    txtFileName.Text = dr("fileName").ToString
                    txtFilePath.Text = dr("filePath").ToString
                    txtDescription.Text = dr("shortcutDescription").ToString
                    lblStatusUID.Text = "UID: " + txtUID.Text
                    lblStatusName.Text = "Shortcut Name: " + txtShortcut.Text
                    validCard = True
                    RichTextBox1.Text &= "UID Match found in list!" & vbCrLf
                    lblStatus.Text = "Card Link Found in list!"
                    grpStatus.BackColor = Color.DarkSeaGreen
                    Button1.Text = "Update Link Information"
                    Button1.Enabled = False
                    GroupBox1.Text = "Edit Link Data"

                    'New process won't be able to access depending files unless we set the working directory instead of launching directly from file path and set UseShellExecute to true -- Most applications will crash trying to launch otherwise
                    Dim myProcess As New Process()
                    myProcess.StartInfo.UseShellExecute = True
                    myProcess.StartInfo.WorkingDirectory = txtFilePath.Text
                    myProcess.StartInfo.FileName = txtFileName.Text
                    myProcess.Start()
                    RichTextBox1.Text &= "Now Launching " + txtShortcut.Text + "..." & vbCrLf & vbCrLf
                    If (ConnectToolStripMenuItem2.Checked And Me.WindowState = FormWindowState.Minimized) Then
                        NotifyIcon1.BalloonTipText = "SUPERCARD: Now Launching - " + txtShortcut.Text + "..."
                        NotifyIcon1.ShowBalloonTip(250)
                    End If
                End While
                cn.Close()
                'Exit Sub
                'Card scan ok, but no link logic
                If validCard = False Then
                    If ComPortToolStripMenuItem.Checked Then
                        My.Computer.Audio.Play(My.Resources.FFVIINo2, AudioPlayMode.Background)
                    End If
                    RichTextBox1.Text &= "ERROR: No link has been created for this card... Add link to a program below" & vbCrLf & vbCrLf
                    txtUID.Text = receivedData
                    lblStatusUID.Text = "UID: " + receivedData
                    lblStatusName.Text = "Shortcut Name: No shortcut linked with this card"
                    grpStatus.BackColor = Color.PaleVioletRed
                    txtFilePath.Text = ""
                    txtShortcut.Text = ""
                    txtDescription.Text = ""
                    txtSFX.Text = ""
                    txtFileName.Text = ""
                    Button1.Text = "Add New Card Link"
                    Button1.Enabled = False
                    lblStatus.Text = "Scan OK, But No Link Found -- Create New Link Below"
                    GroupBox1.Text = "Create New Link"
                End If
            Catch ex As Exception
                cn.Close()
                'validCard = False
                lblStatus.Text = "Error reading from database"
            End Try

            'Once a matching UID is found in the catalog, we'll need to set lables and textboxes accordingly as well as play the corrosponding osund effect

            'If the card read was successful, but there was no link; We need to set labels and change the info box to add new card mode
            grpStatus.Text = "Last Scan -  " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

            'Total card read error
        ElseIf receivedData <> "" And receivedData <> "OK" Then
            RichTextBox1.Text &= "Scan Error" & vbCrLf
            lblStatus.Text = "Card Read Error"
            grpStatus.BackColor = Color.PaleVioletRed
        End If
    End Sub

    'If the serial port sends data and all of it is recieved, return data as a string
    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort1.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function

    'If apply buton was disabled for some reason and we've scanned a card with a link, enable it
    Private Sub enableEditButtonOnText()
        If Not Button1.Enabled And validCard Then
            Button1.Enabled = True
            lblStatus.Text = "Click button to apply changes."
        ElseIf txtUID.Text <> "" And txtShortcut.Text <> "" And txtFilePath.Text <> "" And Not validCard Then
            Button1.Enabled = True
            lblStatus.Text = "Click button to add Card Link"
            grpStatus.BackColor = Color.LightGoldenrodYellow
        ElseIf txtUID.Text = "" Or txtShortcut.Text = "" Or txtFilePath.Text = "" Then
            Button1.Enabled = False
            lblStatus.Text = "Please fill all required fields."
        End If
    End Sub

    'OUTDATED: Was used for console box, but have hidden since. 
    Private Sub clear_BTN_Click(sender As Object, e As EventArgs) Handles clear_BTN.Click
        RichTextBox1.Text = ""
    End Sub

    'Only allow updating link information if one of the text boxes has changed
    Private Sub txtUID_TextChanged(sender As Object, e As EventArgs) Handles txtUID.TextChanged
        enableEditButtonOnText()
    End Sub

    Private Sub txtFilePath_TextChanged(sender As Object, e As EventArgs) Handles txtFilePath.TextChanged
        enableEditButtonOnText()
    End Sub

    Private Sub txtShortcut_TextChanged(sender As Object, e As EventArgs) Handles txtShortcut.TextChanged
        enableEditButtonOnText()
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        enableEditButtonOnText()
    End Sub

    Private Sub txtSFX_TextChanged(sender As Object, e As EventArgs) Handles txtSFX.TextChanged
        enableEditButtonOnText()
        btnSoundPreview.Enabled = True
    End Sub

    'Update or add new card on button clock accordingly
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If validCard Then
            Try
                Call connection()
                cm = New OleDb.OleDbCommand
                With cm
                    .Connection = cn
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE Table1 SET sfxFilePath = '" & txtSFX.Text & "' WHERE (UID = '" & txtUID.Text & "')"
                    cm.ExecuteNonQuery()
                    cn.Close()
                    Button1.Enabled = False
                    Button1.Text = "Updated!"
                    lblStatus.Text = "Link information updated! Scan again to see changes"
                End With
            Catch ex As Exception

            End Try
        Else
            Try
                Call connection()
                cm = New OleDb.OleDbCommand
                With cm
                    .Connection = cn
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO table1 (UID, filePath, sfxFilePath, fileName, shortcutName, shortcutDescription) VALUES (@UID, @filePath, @sfxFilePath, @filename, @shortcutName, @shortcutDescription)"
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@UID", System.Data.OleDb.OleDbType.VarChar, 255, Me.txtUID.Text))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@filePath", System.Data.OleDb.OleDbType.VarChar, 255, Me.txtFilePath.Text))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@sfxFilePath", System.Data.OleDb.OleDbType.VarChar, 255, Me.txtSFX.Text))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@fileName", System.Data.OleDb.OleDbType.VarChar, 255, Me.txtFileName.Text))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@shortcutName", System.Data.OleDb.OleDbType.VarChar, 255, Me.txtShortcut.Text))
                    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@shortcutDescription", System.Data.OleDb.OleDbType.VarChar, 255, Me.txtDescription.Text))

                    cm.Parameters("@UID").Value = Me.txtUID.Text
                    cm.Parameters("@filePath").Value = Me.txtFilePath.Text
                    cm.Parameters("@sfxFilePath").Value = Me.txtSFX.Text
                    cm.Parameters("@fileName").Value = Me.txtFileName.Text
                    cm.Parameters("@shortcutName").Value = Me.txtShortcut.Text
                    cm.Parameters("@shortcutDescription").Value = Me.txtDescription.Text
                    cm.ExecuteNonQuery()
                    cn.Close()
                    Button1.Enabled = False
                    lblStatus.Text = "Card Link added! Scan again to launch."
                    grpStatus.BackColor = Color.LightBlue
                End With
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("                                       -SUPERCARD RFID Launcher-" + vbCrLf + "                                       Version 0.1.2 (In Development)" + vbCrLf + vbCrLf + "System designed and programmed by: Joshua Stimpert" + vbCrLf + vbCrLf + "Contact: jStimpert0430@gmail.com" + vbCrLf + "-------------------------------------------------------------" + vbCrLf + vbCrLf + vbCrLf + "This program is intended to be used in conjunction with an Arduino and RC522 RFID module running custom software in order to launch various user made shortcuts and webpages using a 1kb RFID card's 4 byte UID as a primary key")
    End Sub

    Private Sub ComPortToolStripMenuItem_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ComPortToolStripMenuItem.DropDownItemClicked
        e.ClickedItem.Select() ' = False
        ConnectToolStripMenuItem2.Enabled = True
    End Sub

    Private Sub btnFileBrowse_Click(sender As Object, e As EventArgs) Handles btnFileBrowse.Click
        Dim filePathFinder As New OpenFileDialog()
        filePathFinder.Filter = "All files (*.*)|*.*"
        filePathFinder.Multiselect = False
        'filePathFinder.DereferenceLinks = True
        If filePathFinder.ShowDialog = DialogResult.OK Then
            txtFilePath.Text = filePathFinder.FileName
            Dim testFile As System.IO.FileInfo
            testFile = My.Computer.FileSystem.GetFileInfo(txtFilePath.Text)
            txtFilePath.Text = testFile.DirectoryName + "\"
            txtFileName.Text = testFile.Name
            tempFilename = testFile.Name
            'tempFilename = System.IO.Path.GetFileNameWithoutExtension(filePathFinder.FileName)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSFXBrowse.Click
        Dim filepathFinder As New OpenFileDialog()
        filepathFinder.Filter = "Wav sound clips (*.WAV)|*.WAV"
        filepathFinder.Multiselect = False
        If filepathFinder.ShowDialog = DialogResult.OK Then
            txtSFX.Text = filepathFinder.FileName

        End If
    End Sub

    Private Sub btnSoundPreview_Click(sender As Object, e As EventArgs) Handles btnSoundPreview.Click
        If txtSFX.Text <> "" Then
            If ComPortToolStripMenuItem.Checked Then
                My.Computer.Audio.Play(txtSFX.Text, AudioPlayMode.Background) 'TODO: Link this sound effect to a possible user set one, or just use the default
            End If
        End If
    End Sub

    'OLD - was using when I was trying to set up DB connection
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Table1DataGridView.Select()
        Me.Validate()
        Me.Table1BindingSource.EndEdit()
        ' Me.Table1TableAdapter.Update(Me.CardStorageDataSet.Table1)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            Me.Hide()
            NotifyIcon1.BalloonTipText = "'SUPERCARD RFID launcher' minimized to system tray. Click icon in tray reopen."
            NotifyIcon1.ShowBalloonTip(350)
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        'If Me.WindowState = FormWindowState.Minimized Then
        'NotifyIcon1.Visible = False
        'Me.Show()
        'Me.WindowState = FormWindowState.Normal
        ' End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = MouseButtons.Left Then
            NotifyIcon1.Visible = False
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub autoconnect()
        While True

            For Each p As String In My.Computer.Ports.SerialPortNames
                Try
                    Using com As IO.Ports.SerialPort =
               My.Computer.Ports.OpenSerialPort(p)
                        com.ReadTimeout = 2000
                        com.WriteTimeout = 1000
                        com.BaudRate = 9600
                        com.DataBits = 8
                        com.Parity = Parity.None
                        com.StopBits = StopBits.One
                        com.Handshake = Handshake.None
                        com.Encoding = System.Text.Encoding.Default 'very important!
                        Try
                            com.Write("-")
                        Catch ex As Exception
                        End Try

                        Dim data As String = com.ReadExisting()

                        If InStr(data, "OK") Then
                            comPORT = p
                            lblStatusConnection.Text = "Scanner: Connected and listening to SUPERCARD on " + comPORT
                            com.DiscardInBuffer()
                            com.DiscardOutBuffer()
                            Exit While
                        End If
                        com.Close()
                    End Using
                Catch ex As Exception
                End Try
            Next
        End While
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'myThread.Start()
        autoconnect()

    End Sub

    Private Sub ComPortDropdown_Click(sender As Object, e As EventArgs) Handles ComPortDropdown.Click

    End Sub

    Private Sub ComPortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComPortToolStripMenuItem.Click

    End Sub

    Private Sub ShowBalloonTipsOnLaunchToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PlaySoundsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConnectToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem2.Click

    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        MsgBox("                                       -SUPERCARD RFID Launcher-" + vbCrLf + "                                       Version 0.1.2 (In Development)" + vbCrLf + vbCrLf + "System designed and programmed by: Joshua Stimpert" + vbCrLf + vbCrLf + "Contact: jStimpert0430@gmail.com" + vbCrLf + "-------------------------------------------------------------" + vbCrLf + vbCrLf + vbCrLf + "This program is intended to be used in conjunction with an Arduino and RC522 RFID module running custom software in order to launch various user made shortcuts and webpages using a 1kb RFID card's 4 byte UID as a primary key")

    End Sub
End Class
