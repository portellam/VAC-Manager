using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VACM.GUI.NET4_0
{
    public class Common
    {
        #region Application name logic

        public readonly static string ApplicationNameAsAbbreviation = "VACM";

        public readonly static string FileExtension = "." +
            ApplicationNameAsAbbreviation.ToLower();

        public readonly static string ReferencedApplicationName = "Virtual Audio Cable";
        public readonly static string ReferencedFileExtension = ".vac";

        #endregion

    }
}
