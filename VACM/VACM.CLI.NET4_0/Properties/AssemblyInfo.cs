﻿using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("VAC Manager")]

[assembly: AssemblyDescription("User interface to create, manage, and automate " +
    "instances of Virtual Audio Cable (VAC) audio repeaters. This application version" +
    " is targeted for the 32-bit (x86) version of Virtual Audio Cable, Microsoft .NET" +
    " version 4.0, and Microsoft Windows NT version 5.0 and above (XP/Server 2003 or " +
    "newer).")]

[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Virtual Audio Cable Manager")]

[assembly: AssemblyCopyright("VAC Manager Copyleft © 2024 Alexander Portell." +
    "\nVirtual Audio Cable Copyright © 1998-2024 Eugene V. Muzychenko.")]

[assembly: AssemblyTrademark("VACM")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("eb6fdb02-bd75-4d76-9a0c-be4f92d46c58")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]