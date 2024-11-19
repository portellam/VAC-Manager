# Virtual Audio Cable Audio Repeater Manager
**or** *VAC Audio Repeater Manager*
### In Development
Easily multiplex multiple audio sources. Create, manage, and automate
instances of [Virtual Audio Cable](#Licensing) (VAC) audio repeaters. Compatible
with Microsoft Windows 2000 to Windows 11.

### ~[Download](#4-download)~

## Table of Contents
- [1. Why?](#1-why)
- [2. Features](#2-features)
- [3. Requirements](#3-requirements)
    - [3.1. Example](#31-example)
    - [3.2. Operating System Requirements](#32-operating-system-requirements)
- [4. Download](#4-download)
- [5. Usage](#5-usage)
    - [5.1. Install](#51-install)
- [6. Contact](#6-contact)
- [7. Keywords](#7-keywords)
- [8. Credits](#8-credits)
- [9. Licenses](#9-licenses)

## 1. Why?
- Allows for [multiplexing](#71-multiplexing) of audio streams, of which is
not natively supported in Microsoft Windows.
- For example, effectively treat a
[video game session](#11-use-case-software-defined-multiplexing) like a
[music recording](#12-real-world-equivalent-hardware-defined-multiplexing).
- **Turnkey** solution, no tedious work of opening or closing instances of VAC
audio repeater.

### 1.1. Use-case: Software-defined Multiplexing
Given:
- one (1) Gaming PC
  * to play video games
  * to run [VACARM](#virtual-audio-cable-audio-repeater-manager)
- one (1) Recording PC
- three (3) audio sources:
  * a local microphone.
  * incoming voice chat audio.
  * game audio.
- cables and/or adapters to transfer audio (and video) from the Gaming PC to the
Recording PC.
 
Allows:
1. Specify to only listen to two of the three audio sources
(incoming voice and game audio) on the Gaming PC.
2. Record each source as separate audio streams on the Recording PC,
for future audio/video editing.
3. Optional: stream the audio and video via a Stream client on either PC.

### 1.2. Real-world equivalent: Hardware-defined Multiplexing
`(Come on, Dave, give me a break)` - *Unchained*, Van Halen

Given:
- multiple incoming audio sources (instruments and microphones).
- a time-keeping audio source (a Metronome).
- the incoming/outgoing communication between audio engineer and band.

Allows:
1. Listen to all sources together, but record separately. 
    a. Record all channels from music band separately, for optimal future
remastering.
    b. Allow for future editor(s) to mitigate unnecessary audio sources
(time-keeping audio and audio engineer communication) within master recording.

## 2. Features
- Load/Save audio stream setup to/from file.
- Manage audio stream setup of current or other Windows machine(s).
- Start/stop audio repeaters from within the application.
- Easily automate audio stream setup with Windows Tasks and startup scripts.

## 3. Requirements
- [VAC Audio Repeater](https://vac.muzychenko.net/en/repeater.htm)
- [VAC Control Panel](https://vac.muzychenko.net/en/download.htm)
<sup>[**1**](#31-example)</sup>

### 3.1. Example
A minimum of one (1) virtual audio cable (Line-In and Line-Out pair) to
faciliate [multiplexing](#71-multiplexing).

### 3.2. Operating System Requirements
| Minimum OS version                         | CPU architecture | .NET version  |
| :---                                       | :---:            | :---:         |
| Windows 10 ver. 1809 or Server 2019        | 32-bit or 64-bit | Core 8.0  	|
| Windows 7 SP1 or Server 2008 R2            | 32-bit or 64-bit | Framework 4.8 |
| Windows Vista SP2 or Server 2008 SP2       | 32-bit or 64-bit | Framework 4.6 |
| Windows XP SP3 or Server 2003 SP2          | 32-bit           | Framework 4.0 |

## 4. Download
**No release is available at this time.**

- Download the Latest Release:&ensp;~[Codeberg][codeberg-releases],
[GitHub][github-releases]~

[codeberg-releases]: https://codeberg.org/portellam/VAC-Manager/releases/latest
[github-releases]:   https://github.com/portellam/VAC-Manager/releases/latest

## 5. Usage
### 5.1. Install
TODO: add details here.

### 5.2. Graphics User Interface (GUI) version
TODO:
- add details here.
- make `vac-manager.exe`

### 5.3. Command Line Interface (CLI) version
TODO:
- explain console version input parameters.
- make `vac-manager-cli.exe`

## 6. Contact
Did you encounter a bug? Do you need help? Please visit the
**Issues page** ([Codeberg][codeberg-issues], [GitHub][github-issues]).

[codeberg-issues]: https://github.com/portellam/vac-manager/issues
[github-issues]:   https://github.com/portellam/vac-manager/issues

## 7. Keywords
### 7.1. Multiplexing
In the scope of this project: one *virtual* Line-In to one or more *physical*
Line-Out(s).

*In telecommunications and computer networking, multiplexing*
*(sometimes contracted to muxing) is a method by which multiple analog or*
*digital signals are combined into one signal over a shared medium.*
[Wikipedia](k1)

[k1]: https://en.wikipedia.org/wiki/Multiplexing

## 8. Credits
[Eugene Muzychenko][credits1] for creating Virtual Audio Cable.

[credits1]: https://eugene.muzychenko.net/EMuzychenko_Resume_Eng.htm

## 9. Licenses
Virtual Audio Cable Copyright © 1998-2024 Eugene V. Muzychenko.

VAC Manager GPL-3.0, Copyleft © 2024 Alexander Portell.