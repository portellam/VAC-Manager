# Virtual Audio Cable Audio Repeater Manager
**or *VAC Audio Repeater Manager***
### In Development
Easily multiplex multiple audio sources. Create, manage, and automate
instances of [Virtual Audio Cable](#Licensing) (VAC) audio repeaters. Compatible
with Microsoft Windows XP SP3 to 10/11.

### ~[Download](#4-download)~

## Table of Contents
- [1. Why?](#1-why)
- [2. Features](#2-features)
- [3. Requirements](#3-requirements)
    - [3.1. Operating System Requirements](#31-operating-system-requirements)
- [4. Download](#4-download)
- [5. Usage](#5-usage)
    - [5.1. Install](#61-install)
- [6. Contact](#7-contact)
- [7. Keywords](#8-keywords)
- [8. Credits](#8-credits)
- [9. Licenses](#9-licenses)

## Contents
### 1. Why?
- Allows for multiplexing of audio streams, of which is not natively supported in
Microsoft Windows.
- Examples include (but not limited to):
  * video game session recording/stream setup.<sup>[**1**]</sup>
  * music recording.<sup>[**2**]</sup>
- Turnkey solution, no tedious work of opening or closing instances of VAC
audio repeater.

**[1]** Given three audio sources, a local microphone, incoming voice chat audio,
and game audio: record each source as separate audio streams; and specify to only
listen to two of the three audio sources (incoming voice and game audio).

**[2]** Given multiple incoming audio sources (instruments and microphones),
a time-keeping audio source (a Metronome), and the incoming/outgoing voice chat
between audio engineer and music band: record all channels from music band
separately, for optimal future remastering; allow for future editor(s) to mitigate
time-keeping audio and audio engineer communication within master recording.
`Come on Dave, give me a break...` - *Unchained*, Van Halen

### 2. Features
- Load/Save audio stream setup to/from file.
- Manage audio stream setup of current or other Windows machine(s).
- Start/stop audio repeaters from within the application.
- Easily automate audio stream setup with Windows Tasks and startup scripts.

## 3. Requirements
- [VAC Audio Repeater](https://vac.muzychenko.net/en/repeater.htm)
- [VAC Control Panel](https://vac.muzychenko.net/en/download.htm)<sup>[**1**]</sup>

**[1]** A minimum of one (1) virtual audio cable (Line-In and Line-Out pair) to
faciliate [Mutiplexing](#1-multiplexing). Example: one (1) *virtual* Line-In > one
or more *physical* Line-Out(s).

### 3.1. Operating System Requirements
| Minimum OS version                         | CPU architecture | .NET version  |
| :---                                       | :---:            | :---:         |
| Windows 10 ver. 1809 or Server 2019        | 32-bit or 64-bit | 8.0		  	    |
| Windows 7 SP1 or Server 2008 R2            | 32-bit or 64-bit | Framework 4.8 |
| Windows Vista SP2 or Server 2008 SP2       | 32-bit or 64-bit | Framework 4.6 |
| Windows XP SP3 or Server 2003 SP2          | 32-bit           | Framework 4.0 |

### 4. Download
**No release is available at this time.**

- Download the Latest Release:&ensp;~[Codeberg][codeberg-releases],
[GitHub][github-releases]~

[codeberg-releases]: https://codeberg.org/portellam/VAC-Manager/releases/latest
[github-releases]:   https://github.com/portellam/VAC-Manager/releases/latest

### 5. Usage
#### 5.1. Install
TODO: add details here.

#### 5.2. Graphics User Interface (GUI) version
TODO:
- add details here.
- make `vac-manager.exe`

#### 5.3. Command Line Interface (CLI) version
TODO:
- explain console version input parameters.
- make `vac-manager-cli.exe`

### 6. Contact
Did you encounter a bug? Do you need help? Please visit the
**Issues page** ([Codeberg][codeberg-issues], [GitHub][github-issues]).

[codeberg-issues]: https://github.com/portellam/vac-manager/issues
[github-issues]:   https://github.com/portellam/vac-manager/issues

## 7. Keywords
#### 1. Multiplexing
*In telecommunications and computer networking, multiplexing*
*(sometimes contractedto muxing) is a method by which multiple analog or digital*
*signals are combined into one signal over a shared medium.* [Wikipedia](k1)

[k1]: https://en.wikipedia.org/wiki/Multiplexing

## 8. Credits
[Eugene Muzychenko][credits1] for creating Virtual Audio Cable.

[credits1]: https://eugene.muzychenko.net/EMuzychenko_Resume_Eng.htm

## 9. Licenses
Virtual Audio Cable Copyright © 1998-2024 Eugene V. Muzychenko.

VAC Manager GPL-3.0, Copyleft © 2024 Alexander Portell.