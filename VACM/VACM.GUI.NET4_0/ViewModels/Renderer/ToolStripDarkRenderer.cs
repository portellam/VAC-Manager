using System.Windows.Forms;
using VACM.GUI.NET4_0.ViewModels.ColorTable;

namespace VACM.GUI.NET4_0.ViewModels.Renderer
{
    public class ToolStripDarkRenderer : ToolStripProfessionalRenderer
    {
        #region Parameters

        private readonly DarkColorTable darkColorTable = new DarkColorTable();

        public ToolStripProfessionalRenderer ToolStripProfessionalRenderer =>
            new ToolStripProfessionalRenderer(darkColorTable);

        public new ProfessionalColorTable ColorTable
        {
            get
            {
                return darkColorTable;
            }
        }

        #endregion
    }
}
