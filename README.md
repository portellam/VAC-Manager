# Virtual Audio Cable Manager
User interface to create, manage, and automate instances of [Virtual Audio Cable](#licenses) (VAC) audio repeaters for Microsoft Windows. Includes GUI and Console applications. Supports Windows XP to Windows 11.

**[~Latest release~](#https://github.com/portellam/vac-manager/releases/latest) | [View master branch...](https://github.com/portellam/vac-manager/tree/master)**

## Table of Contents
- [What is VAC?](#what-is-vac)
  - [1. VAC Control Panel](#1-vac-control-panel) 
  - [2. VAC Audio Repeater](#2-vac-audio-repeater)
- [Why?](#why)
  - [1. Mirror Audio Sources](#1-mirror-audio-sources)
  - [2. Multiplexing](#2-multiplexing)
- [Download](#download)
- [Features](#features)
- [Requirements](#requirements)
- [Keywords](#keywords)
- [Credits](#credits)
- [Licenses](#licenses)

### What is VAC?
*VAC* is a software suite which includes an Audio Repeater, and Control Panel.

#### 1. VAC Control Panel
*VAC Control Panel* allows for the creation of Virtual Audio devices (Cables) or VACs.
VACs are created in pairs; one Line-In (input, capture) and Line-Out (output, render).
Many VAC pairs may be created.

#### 2. VAC Audio Repeater
*VAC Audio Repeater* is a useful tool which allows for an audio stream to passthrough between two devices (cables).
By default, Windows will allow for up to one output cable to "listen" to one input, equivalent to an "audio repeater".
*VAC Audio Repeater* allows for many more of these to exist.

### Why?
#### 1. Mirror Audio Sources
By default, Windows allows for a Video source to be mirrored across multiple displays.
**VAC Manager** aims to do the same, but for Audio and with a nice user interface.

#### 2. Multiplexing
Want to broadcast video game audio and voice chat together to your headphones, but on separate lines for game session recording or streaming? You can do that.

Or you want to play music directly to your voice chat, by a virtual microphone? You can do that, too.

These examples are known as **[multiplexing](#multiplexing)**.

### Download
See the [Releases](https://github.com/portellam/vac-manager/releases) tab.

### Features
- Load/Save audio stream setup to/from file.
- Manage audio stream setup of current or foreign Windows machine(s).
- Easily automate audio stream setup with Windows Tasks and startup scripts.
- Fault-tolerance of audio device disconnect or reconnect.
- WinForm GUI application
- Console application

### Requirements
- [VAC Audio Repeater](https://vac.muzychenko.net/en/repeater.htm)
- [VAC Control Panel](https://vac.muzychenko.net/en/download.htm)
- Microsoft Windows:
  - 32-bit (x86) and `.NET 4.0`: NT 5.0; XP and Server 2003.
  - 64-bit (x64) and `.NET 4.8`: NT 6.0 and 6.1; Vista and 7.
  - 64-bit (x64) and `.NET 8.0`: NT 8 and above; 8, 8.1, 10, and 11.
- A minimum of one *VAC* pair.

### Keywords
#### multiplexing
*In telecommunications and computer networking, multiplexing (sometimes contracted to muxing) is a method by which multiple analog or digital signals are combined into one signal over a shared medium.* [Wikipedia](https://en.wikipedia.org/wiki/Multiplexing)

### Credits
[Eugene Muzychenko](https://eugene.muzychenko.net/EMuzychenko_Resume_Eng.htm) for creating Virtual Audio Cable.

### Licenses
Virtual Audio Cable Copyright © 1998-2024 Eugene V. Muzychenko.

VAC Manager GPL-3.0, Copyleft © 2024 Alexander Portell.
