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

        #region Logic

        /// <summary>
        /// Set the arrow color to the color table fore color.
        /// </summary>
        /// <param name="toolStripArrowRenderEventArgs">The tool strip arrow render
        /// event arguments</param>
        protected override void OnRenderArrow
            (ToolStripArrowRenderEventArgs toolStripArrowRenderEventArgs)
        {
            toolStripArrowRenderEventArgs.ArrowColor = darkColorTable.ForeColor;
            base.OnRenderArrow(toolStripArrowRenderEventArgs);
        }

        #endregion
    }
}
