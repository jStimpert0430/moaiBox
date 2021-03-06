# MoaiBox - V 0.2

MoaiBox is an RFID based application launcher which uses an Arduino Uno, an RC522 rfid module, and a VB.net windows form application in order to link a shortcut to a card and launch it on scan. Supports minizing to taskbar and custom sound effects

<p align="center">
  <img src="https://github.com/jStimpert0430/moaiBox/blob/master/moaiBoxDevice.png/?raw=true" alt="Device in enclosure"/>
</p>

## Program Demonstration

[![Device Demonstration](https://puu.sh/B0Xoj/ed81b4688e.png)](https://www.youtube.com/watch?v=YeyGDXBv5A0&feature=youtu.be "MoaiBox video demonstration")

## Why

This system was mainly developed to meet the requirements for a school project in a Systems Design and Development course for my Computer Science degree; My main goal in creating this system was to bring tactility to digital content; I miss have to actually handle physical media in order to use it, and had thought this might be a good way to bridge the gap between purely digital content, and the physical media of yesterday; Cards and keyfob scanning seemed like it may have been an interesting solution.

## How does it work?

The program functions by using the card's UID as a primary key in a table which houses a shortcut URI and various other information about the link. Any file that can be referenced by an address or web address can be launched with this application or one can directly launch webpages by inputting a web address instead of a filepath.


* The bulk of functionality found in this system is housed within the windows form program itself; The only thing the arduino is responsible for is initializing the form, reading the UID of the card, and sending it over the com port. 
* On launch, the windows form starts a timer and loops though the com ports found on the system sending a handshake bit and waiting for a reply;
* Once the form recieves an 'OK' from an arduino device plugged into a com port that had been waiting for the handshake bit; both devices switch to the main program loops and are ready to both scanning and reacting.
* At this point, the windows form will continue listening to the com port until it recieves a complete UID that isn't blank, once a valid UID is recieved; The form performs a select statement on a local database to see if there are any matching UID's already housed here.
* If there are, the form will launch the shortcut tied to this entry, set the textboxes in the form to their corrosponding data, show any notifications, and change to card update mode;
* If not, the form will copy the new UID of the card into the UID Textbox and switch to new card mode.

## Getting Started

Open visual studio project in a compatable editor of your choice(Project was created in visual studio 2015) then either edit or build the project

### Prerequisites

1. A windows computer XP or newer with at least 64mb of free ram
2. A free USB port
3. An Authentic Arduino Uno (Note: From my personal testing, arduino knockoffs that use additional drivers to communicate seem to struggle with the auto connect code; If you want to use a knockoff you might need to re-enable manual com port selection in the code)
4. An RC522 rfid read/writer module for arduino
5. Miifare 1k Rfid storage medium
6. MiguelBabloa's RC522 library (https://github.com/miguelbalboa/rfid)

### Installing

![Device Pinouts](DevicePinouts.png)

1. Connect RC522 module to arduino following the pinouts specified on the image included with the project.
2. (If required) Install Arduino software and drivers to enable COM communication in windows
3. Open Arduino IDE, click sketch, click include library, add ZIP library, and point to the zip downloaded from MiguelBalboa's repository.
4. Open sketch_feb28b.ino and flash to Arduino Uno
5. Open Visual Studio project and either play or compile
6. OPTIONAL--3D print device case with included cura files(Small version is arduino nano, big version is for an uno)

Program is open, connected, and ready to read cards!

![Case Steps](caseSteps.png)

## Using the program

1. (Device Connection)
-Once the MoaiBox reader has been assembled, simple plug in and launch the program; The application will attempt to talk to device on the com ports until the MoaiBox itself responds, and initiated the connection logic pointed at that port.

2. (Creating Links)
-To create a new link, simply scan a card that hasn't been linked with the system to auto fill it's UID.
-Click the shortcut browse button and find a program you would like to launch with this card
-Set the name, description, and add a custom sound effect
-Click the add link button to finalize the link
-Scan card again to launch shortcut

3. (Editing links)
-Scan a card which already has a link tied to it's UID
-Edit fields in main program as desired
-Click update link button at bottom of the program
-Scan again to see changes.

<p align="center">
  <img src="https://github.com/jStimpert0430/moaiBox/blob/master/program.png/?raw=true" alt="Program Window"/>
</p>


## Built With

* [Visual Studio 2015 - VB.net] - Environment and language used
* [Arduino 1.6.9] - To create and upload programs to the Arduino Uno
* [Open SCAD] - Case 3D print design
* [Ultimaker Cura] - 3D print slicer
	

## Version History

* 0.2 - Added Database card info storage / program customization
* 0.1 - Initial Version of system

## Known bugs

* Currently, device disconnect logic while the program is running will cause the program to crash. Need to add additional try catch statements in order to handle exceptions caused.
* Custom sound effects won't be updated upon update link, need to add sound effects to update statements
* Device never resets to initial state without unplugging first - still sends handshake if the form asks for it though.

## Developer notes
This is very much a prototype application, and probably not one ment for any serious deployment; I'm not sure if I'll ever personally get back to this project as when I actually put the use to practice, it wasn't that much more engaging to use than just clicking an icon on the desktop was; That said,all critical functionality required for this system to function is in place and even in this form it's still pretty usable once the device is built. Feel free to take this, update it, modify it, or use any part of it in your own programs. The Arduino Scanner program only sends the UID of the card in hex format over the serial connection, this could easily be reporposed for any other application requiring a unique number over the com port.

## Author

Joshua Stimpert

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


