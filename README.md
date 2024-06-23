# Virtual Audio Cable Manager
### v0.5.1
User interface to create, manage, and automate instances of
[Virtual Audio Cable](#licenses) (VAC) audio repeaters for Microsoft Windows.
Includes GUI and Console applications. Supports Windows XP to Windows 11.

## Status: In-Development

## Table of Contents
- [1. What is VAC?](#1-what-is-vac)
    - [1.1. VAC Control Panel](#11-vac-control-panel)
    - [1.2. VAC Audio Repeater](#12-vac-audio-repeater)
- [2. Why?](#2-why)
    - [2.1. Mirror Audio Sources](#21-mirror-audio-sources)
    - [2.2. Multiplexing](#22-multiplexing)
- [3. Requirements](#3-requirements)
- [4. Download](#4-download)
- [5. Features](#5-features)
- [6. Keywords](#6-keywords)
    - [6.1. Multiplexing](#21-multiplexing)
- [7. Credits](#7-credits)
- [8. Licenses](#8-licenses)
- [9. Contact](#9-contact)

## Contents
### 1. What is VAC?
**Virtual Audio Cable** or **VAC** is a software suite which includes an
Audio Repeater application, and a Control Panel to run one or more Audio
Repeater(s) as desired.

#### 1.1. VAC Control Panel
*VAC Control Panel* allows for the creation of Virtual Audio devices (Cables) or
VACs. VACs are created in pairs; one Line-In (input, capture) and Line-Out
(output, render). Many VAC pairs may be created.

#### 1.2. VAC Audio Repeater
*VAC Audio Repeater* is a useful tool which allows for an audio stream to
passthrough between two devices (cables). By default, Windows will allow for up
to one output cable to "listen" to one input, equivalent to an "audio repeater".
*VAC Audio Repeater* allows for many more of these to exist.

### 2. Why?
#### 2.1. Mirror Audio Sources
By default, Windows allows for a Video source to be mirrored across multiple
displays. **VAC Manager** aims to do the same, but for Audio and with a nice
user interface.

#### 2.2. Multiplexing
Want to broadcast video game audio and voice chat together to your headphones,
but on separate lines for game session recording or streaming? You can do that.

Or you want to play music directly to your voice chat, by a virtual microphone?
You can do that, too.

These examples are known as **[multiplexing](#multiplexing)**.

### 3. Requirements
- A minimum of one **VAC** pair (one virtual input cable and one virtual output
cable).

- [VAC Audio Repeater]
- [VAC Control Panel]

[VAC Audio Repeater]: https://vac.muzychenko.net/en/repeater.htm
[VAC Control Panel]: https://vac.muzychenko.net/en/download.htm

| .NET version                                                                     | CPU architecture | Microsoft Windows version          |
| :------------------------------------------------------------------------------- | :--------------: | :--------------------------------- |
| [.NET 4.0](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net40)   | 32-bit (x86)     | NT 5.0: XP and Server 2003         |
| [.NET 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)   | 64-bit (x64)     | NT 6.0 and 6.1; Vista and 7        |
| [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)               | 64-bit (x64)     | NT 8 and above; 8, 8.1, 10, and 11 |

### 4. Download
Download the Latest Release:&ensp;[Codeberg][codeberg-releases],
[GitHub][github-releases]

[codeberg-releases]: https://codeberg.org/portellam/VAC-Manager/releases/latest
[github-releases]:   https://github.com/portellam/VAC-Manager/releases/latest

### 5. Features
- Load/Save audio stream setup to/from file.
- Manage audio stream setup of current or foreign Windows machine(s).
- Easily automate audio stream setup with Windows Tasks and startup scripts.
- Fault-tolerance of audio device disconnect or reconnect.
- WinForm GUI application.
- Command Prompt/Console application.

### 6. Keywords
#### 6.1. Multiplexing
*In telecommunications and computer networking, multiplexing (sometimes*
*contracted to muxing) is a method by which multiple analog or digital signals*
*are combined into one signal over a shared medium.* [Wikipedia article]

[Wikipedia article]: https://en.wikipedia.org/wiki/Multiplexing

### 7. Credits
[Eugene Muzychenko] for creating Virtual Audio Cable.

[Eugene Muzychenko]: (https://eugene.muzychenko.net/EMuzychenko_Resume_Eng.htm)

### 8. Licenses
**Virtual Audio Cable**. Copyright © 1998-2024. Eugene V. Muzychenko.

**VAC Manager**. GPL-3.0, Copyleft © 2024. Alexander Portell.

### 9. Contact
Did you encounter a bug? Do you need help? Please visit the **Issues page**
([Codeberg][codeberg-issues], [GitHub][github-issues]).

[codeberg-issues]: https://codeberg.org/portellam/VAC-Manager/issues
[github-issues]:   https://github.com/portellam/VAC-Manager/issues