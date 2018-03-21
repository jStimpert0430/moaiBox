<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.comPort_ComboBox = New System.Windows.Forms.ComboBox()
        Me.COMport_LBL = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clear_BTN = New System.Windows.Forms.Button()
        Me.connect_BTN = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_LBL = New System.Windows.Forms.Label()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.txtUID = New System.Windows.Forms.TextBox()
        Me.txtShortcut = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnSoundPreview = New System.Windows.Forms.Button()
        Me.btnSFXBrowse = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSFX = New System.Windows.Forms.TextBox()
        Me.btnFileBrowse = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.lblStatusName = New System.Windows.Forms.Label()
        Me.lblStatusUID = New System.Windows.Forms.Label()
        Me.lblStatusConnection = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaySoundsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComPortDropdown = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Table1DataGridView = New System.Windows.Forms.DataGridView()
        Me.Table1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Table1DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Table1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comPort_ComboBox
        '
        Me.comPort_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comPort_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comPort_ComboBox.FormattingEnabled = True
        Me.comPort_ComboBox.Location = New System.Drawing.Point(491, 49)
        Me.comPort_ComboBox.Name = "comPort_ComboBox"
        Me.comPort_ComboBox.Size = New System.Drawing.Size(121, 28)
        Me.comPort_ComboBox.TabIndex = 7
        '
        'COMport_LBL
        '
        Me.COMport_LBL.AutoSize = True
        Me.COMport_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMport_LBL.Location = New System.Drawing.Point(513, 26)
        Me.COMport_LBL.Name = "COMport_LBL"
        Me.COMport_LBL.Size = New System.Drawing.Size(78, 20)
        Me.COMport_LBL.TabIndex = 17
        Me.COMport_LBL.Text = "COM Port"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AutoWordSelection = True
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 599)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(430, 38)
        Me.RichTextBox1.TabIndex = 23
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Console Output"
        Me.Label1.Visible = False
        '
        'clear_BTN
        '
        Me.clear_BTN.Location = New System.Drawing.Point(507, 214)
        Me.clear_BTN.Name = "clear_BTN"
        Me.clear_BTN.Size = New System.Drawing.Size(84, 27)
        Me.clear_BTN.TabIndex = 21
        Me.clear_BTN.Text = "CLEAR"
        Me.clear_BTN.UseVisualStyleBackColor = True
        Me.clear_BTN.Visible = False
        '
        'connect_BTN
        '
        Me.connect_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connect_BTN.Location = New System.Drawing.Point(491, 83)
        Me.connect_BTN.Name = "connect_BTN"
        Me.connect_BTN.Size = New System.Drawing.Size(120, 32)
        Me.connect_BTN.TabIndex = 8
        Me.connect_BTN.Text = "Connect"
        Me.connect_BTN.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Timer_LBL
        '
        Me.Timer_LBL.AutoSize = True
        Me.Timer_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timer_LBL.Location = New System.Drawing.Point(503, 118)
        Me.Timer_LBL.Name = "Timer_LBL"
        Me.Timer_LBL.Size = New System.Drawing.Size(88, 20)
        Me.Timer_LBL.TabIndex = 24
        Me.Timer_LBL.Text = "Timer: OFF"
        Me.Timer_LBL.Visible = False
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(409, 41)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(124, 20)
        Me.txtFilePath.TabIndex = 3
        '
        'txtUID
        '
        Me.txtUID.Location = New System.Drawing.Point(16, 41)
        Me.txtUID.Name = "txtUID"
        Me.txtUID.Size = New System.Drawing.Size(157, 20)
        Me.txtUID.TabIndex = 1
        '
        'txtShortcut
        '
        Me.txtShortcut.Location = New System.Drawing.Point(217, 41)
        Me.txtShortcut.Name = "txtShortcut"
        Me.txtShortcut.Size = New System.Drawing.Size(157, 20)
        Me.txtShortcut.TabIndex = 2
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(16, 158)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(582, 61)
        Me.txtDescription.TabIndex = 5
        Me.txtDescription.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Shortcut Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Shortcut Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(406, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "File Path or Web Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Linked Card's UID"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(197, 238)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(209, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Add New Card Link"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblStatus.Location = New System.Drawing.Point(18, 97)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(257, 20)
        Me.lblStatus.TabIndex = 35
        Me.lblStatus.Text = "Scan card to see Link details below"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.txtFileName)
        Me.GroupBox1.Controls.Add(Me.btnSoundPreview)
        Me.GroupBox1.Controls.Add(Me.btnSFXBrowse)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtSFX)
        Me.GroupBox1.Controls.Add(Me.btnFileBrowse)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFilePath)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtUID)
        Me.GroupBox1.Controls.Add(Me.txtShortcut)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(623, 271)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create New Link"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(539, 41)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(72, 20)
        Me.txtFileName.TabIndex = 38
        '
        'btnSoundPreview
        '
        Me.btnSoundPreview.Enabled = False
        Me.btnSoundPreview.Location = New System.Drawing.Point(260, 112)
        Me.btnSoundPreview.Name = "btnSoundPreview"
        Me.btnSoundPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnSoundPreview.TabIndex = 37
        Me.btnSoundPreview.Text = "Preview"
        Me.btnSoundPreview.UseVisualStyleBackColor = True
        '
        'btnSFXBrowse
        '
        Me.btnSFXBrowse.Location = New System.Drawing.Point(179, 112)
        Me.btnSFXBrowse.Name = "btnSFXBrowse"
        Me.btnSFXBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnSFXBrowse.TabIndex = 36
        Me.btnSFXBrowse.Text = "Browse"
        Me.btnSFXBrowse.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Custom SFX File Path (Leave blank for default)"
        '
        'txtSFX
        '
        Me.txtSFX.Location = New System.Drawing.Point(16, 114)
        Me.txtSFX.Name = "txtSFX"
        Me.txtSFX.Size = New System.Drawing.Size(157, 20)
        Me.txtSFX.TabIndex = 34
        '
        'btnFileBrowse
        '
        Me.btnFileBrowse.Location = New System.Drawing.Point(409, 67)
        Me.btnFileBrowse.Name = "btnFileBrowse"
        Me.btnFileBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnFileBrowse.TabIndex = 4
        Me.btnFileBrowse.Text = "Browse"
        Me.btnFileBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grpStatus)
        Me.GroupBox2.Controls.Add(Me.lblStatusConnection)
        Me.GroupBox2.Controls.Add(Me.Timer_LBL)
        Me.GroupBox2.Controls.Add(Me.clear_BTN)
        Me.GroupBox2.Controls.Add(Me.COMport_LBL)
        Me.GroupBox2.Controls.Add(Me.comPort_ComboBox)
        Me.GroupBox2.Controls.Add(Me.connect_BTN)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(623, 213)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Status Box"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.lblStatusName)
        Me.grpStatus.Controls.Add(Me.lblStatus)
        Me.grpStatus.Controls.Add(Me.lblStatusUID)
        Me.grpStatus.Location = New System.Drawing.Point(39, 59)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(429, 144)
        Me.grpStatus.TabIndex = 1
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Last Scan"
        '
        'lblStatusName
        '
        Me.lblStatusName.AutoSize = True
        Me.lblStatusName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblStatusName.Location = New System.Drawing.Point(163, 35)
        Me.lblStatusName.Name = "lblStatusName"
        Me.lblStatusName.Size = New System.Drawing.Size(110, 13)
        Me.lblStatusName.TabIndex = 1
        Me.lblStatusName.Text = "Shortcut Name: None"
        '
        'lblStatusUID
        '
        Me.lblStatusUID.AutoSize = True
        Me.lblStatusUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblStatusUID.Location = New System.Drawing.Point(19, 35)
        Me.lblStatusUID.Name = "lblStatusUID"
        Me.lblStatusUID.Size = New System.Drawing.Size(58, 13)
        Me.lblStatusUID.TabIndex = 0
        Me.lblStatusUID.Text = "UID: None"
        '
        'lblStatusConnection
        '
        Me.lblStatusConnection.AutoSize = True
        Me.lblStatusConnection.Location = New System.Drawing.Point(35, 26)
        Me.lblStatusConnection.Name = "lblStatusConnection"
        Me.lblStatusConnection.Size = New System.Drawing.Size(184, 20)
        Me.lblStatusConnection.TabIndex = 0
        Me.lblStatusConnection.Text = "Scanner: Not Connected"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ComPortDropdown, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(644, 24)
        Me.MenuStrip1.TabIndex = 38
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlaySoundsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PlaySoundsToolStripMenuItem
        '
        Me.PlaySoundsToolStripMenuItem.Checked = True
        Me.PlaySoundsToolStripMenuItem.CheckOnClick = True
        Me.PlaySoundsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlaySoundsToolStripMenuItem.Name = "PlaySoundsToolStripMenuItem"
        Me.PlaySoundsToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PlaySoundsToolStripMenuItem.Text = "Play Sounds"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ComPortDropdown
        '
        Me.ComPortDropdown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComPortToolStripMenuItem, Me.ConnectToolStripMenuItem2})
        Me.ComPortDropdown.Name = "ComPortDropdown"
        Me.ComPortDropdown.Size = New System.Drawing.Size(64, 20)
        Me.ComPortDropdown.Text = "Connect"
        '
        'ComPortToolStripMenuItem
        '
        Me.ComPortToolStripMenuItem.Name = "ComPortToolStripMenuItem"
        Me.ComPortToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ComPortToolStripMenuItem.Text = "Com Port"
        '
        'ConnectToolStripMenuItem2
        '
        Me.ConnectToolStripMenuItem2.CheckOnClick = True
        Me.ConnectToolStripMenuItem2.Enabled = False
        Me.ConnectToolStripMenuItem2.Name = "ConnectToolStripMenuItem2"
        Me.ConnectToolStripMenuItem2.Size = New System.Drawing.Size(125, 22)
        Me.ConnectToolStripMenuItem2.Text = "Connect"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(516, 610)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Table1DataGridView
        '
        Me.Table1DataGridView.AutoGenerateColumns = False
        Me.Table1DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Table1DataGridView.DataSource = Me.Table1BindingSource
        Me.Table1DataGridView.Location = New System.Drawing.Point(19, 697)
        Me.Table1DataGridView.Name = "Table1DataGridView"
        Me.Table1DataGridView.Size = New System.Drawing.Size(673, 220)
        Me.Table1DataGridView.TabIndex = 40
        Me.Table1DataGridView.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 538)
        Me.Controls.Add(Me.Table1DataGridView)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "SUPERCARD RFID Launcher V 0.1.2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Table1DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Table1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comPort_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents COMport_LBL As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clear_BTN As System.Windows.Forms.Button
    Friend WithEvents connect_BTN As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer_LBL As System.Windows.Forms.Label
    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents txtUID As TextBox
    Friend WithEvents txtShortcut As TextBox
    Friend WithEvents txtDescription As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFileBrowse As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblStatusConnection As Label
    Friend WithEvents grpStatus As GroupBox
    Friend WithEvents lblStatusName As Label
    Friend WithEvents lblStatusUID As Label
    Friend WithEvents btnSFXBrowse As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSFX As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlaySoundsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComPortDropdown As ToolStripMenuItem
    Friend WithEvents ComPortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnectToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents btnSoundPreview As Button
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Table1BindingSource As BindingSource
    Friend WithEvents Button2 As Button
    Friend WithEvents Table1DataGridView As DataGridView
End Class
