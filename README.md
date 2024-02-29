# VAC-Manager
 Open-source user interface to create, manage, and automate instances of [Virtual Audio Cable](#Licensing) (VAC) audio repeaters.

## Installation
Download from "Releases" the setup executable for your Windows machine architecture (32-bit or 64-bit). This application is targeted for Windows NT 5.0 (XP / Server 2003) and newer (Vista / 7 / 8 / 10 / 11).

## Why use this?
* Allow for multiplexing of audio streams for (example: Game broadcast/recording setup).
* For Windows machines with many audio devices, such that the end-user only has to physically turn on or off the audio device, and not in software.

## Features
* Load/Save audio stream setup to/from file.
* Manage audio stream setup of current or foreign Windows machine(s).
* Easily automate audio stream setup with Windows Tasks and startup scripts.

## Requirements
* [VAC Audio Repeater](https://vac.muzychenko.net/en/repeater.htm)
* [VAC Control Panel](https://vac.muzychenko.net/en/download.htm) <sup>[1](#1)</sup>
* Microsoft .NET (version 4.0 for 32-bit, version 4.8 and 8.0 for 64-bit). 

#### 1.
A minimum of one (1) "virtual audio cable" or input-and-output pair to faciliate [multiplexing](#multiplexing). Example: virtual Line In 1 > physical Line out(s).

## Keywords
#### multiplexing
*In telecommunications and computer networking, multiplexing (sometimes contracted to muxing) is a method by which multiple analog or digital signals are combined into one signal over a shared medium.* [Wikipedia](https://en.wikipedia.org/wiki/Multiplexing)

## Credits
[Eugene Muzychenko](https://eugene.muzychenko.net/EMuzychenko_Resume_Eng.htm) for creating Virtual Audio Cable.

## Licensing
Virtual Audio Cable Copyright © 1998-2024 Eugene V. Muzychenko.

VAC Manager GPL-3.0, Copyleft © 2024 Alexander Portell.

## TO DO (subject to change)
- Development:
 - [ ] Choose GUI type: WinForms
	- [ ] Choose design pattern: Model-ViewModel-View
		- [ ] Models
			- [ ] Audio device model
			- [ ] Repeater model
			- [ ] Repeater data model
		- [ ] Views
			- [ ] Main form
				- [ ] Create GUI layout.
				- [ ] Create all hotkeys.
				- [ ] Create all backend logic for accesing and manipulating model data and other forms.
			- [ ] About form
			- [ ] Grid table
				- [ ] Present audio devices and repeaters in heirarchical list format.
				- [ ] Validate Main form logic works here.
			- [ ] Canvas graph
				- [ ] Present audio repeaters as pairs of devices with links on a graph.
				- [ ] Validate Main form logic works here.

	- [ ] Logic
		- [ ] File
			- [ ] Open
			- [ ] New
			- [ ] Save
			- [ ] Close
		- [ ] Devices
			- [ ] Add
			- [ ] Remove
			- [ ] Reload
			- [ ] Import from file (.xml file).
			- [ ] Export from file (.xml file).
		- [ ] Links
		- [ ] Repeaters
			- [ ] Generate automation scripts (.bat files).
			- [ ] Generate Window task (.xml file ?).
		- [ ] Dark mode
	- [ ] Windows 32-bit support
		- [ ] Windows NT 5.x:	.NET 4.0 compatible C# code and NuGet dependencies.
		- [ ] Windows NT 6.x:	.NET 4.8 compatible C# code and NuGet dependencies.
	- [ ] Windows 64-bit support
		- [ ] Windows NT 6.1+:	.NET 4.8 compatible C# code and NuGet dependencies.
		- [ ] Windows NT 10.0+:	.NET 8.0 compatible C# code and NuGet dependencies.

- Unit testing:
	- [ ] Higher priority
		- [ ] Backend logic
	- [ ] Lower priority
		- [ ] Viewmodel logic (NOTE: is this even necessary or feasible with Mocking?).

- [ ] Create installer/uninstaller.

- README
	- [ ] Add demo pics.
