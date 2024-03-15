﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0.ViewModels
{
    public class FormColorUpdater
    {
        #region Parameters

        private static bool IsLightThemeEnabled
        {
            get
            {
                return GraphicsWindow.IsLightThemeEnabled;
            }
        }

        private readonly static Color darkBackColor = Color.FromArgb(60, 63, 65);
        private readonly static Color darkTextColor = Color.White;
        private readonly static Color lightBackColor = Color.White;
        private readonly static Color lightTextColor = Color.Black;

        public static Color BackColor
        {
            get
            {
                if (!IsLightThemeEnabled)
                {
                    return darkBackColor;
                }
                else
                {
                    return lightBackColor;
                }
            }
        }

        public static Color ForeColor
        {
            get
            {
                if (!IsLightThemeEnabled)
                {
                    return darkTextColor;
                }
                else
                {
                    return lightTextColor;
                }
            }
        }

        #endregion

        #region Logic

        /// <summary>
        /// Set the colors of every control in list, given dark mode is enabled or not.
        /// </summary>
        /// <param name="controlList">The control list</param>
        public static void SetColorsOfControlList(List<Control> controlList)
        {
            if (controlList.Count == 0)
            {
                return;
            }

            foreach (Control control in controlList)
            {
                control.BackColor = BackColor;
                control.ForeColor = ForeColor;
                SetColorsOfControlCollection(control.Controls);
            };
        }

        /// <summary>
        /// Set the colors of the tool strip item, given dark mode is enabled or not.
        /// </summary>
        /// <param name="toolStripItem">The tool strip item</param>
        internal static void SetColorsOfToolStripItem
            (ToolStripItem toolStripItem)
        {
            toolStripItem.BackColor = BackColor;
            toolStripItem.ForeColor = ForeColor;

            if (toolStripItem is ToolStripMenuItem)
            {
                SetColorsOfToolStripItem(toolStripItem as ToolStripMenuItem);
            }

        }

        /// <summary>
        /// Set the colors of the tool strip menu item and its tool strip item
        /// collection, given dark mode is enabled or not.
        /// </summary>
        /// <param name="toolStripMenuItem">The tool strip menu item</param>
        internal static void SetColorsOfToolStripItem
            (ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.BackColor = BackColor;
            toolStripMenuItem.ForeColor = ForeColor;

            if (toolStripMenuItem.DropDownItems.Count == 0)
            {
                return;
            }

            foreach (var item in
                toolStripMenuItem.DropDownItems)
            {
                SetColorsOfToolStripItem(item as ToolStripItem);
            }
        }

        /// <summary>
        /// Set the colors of every item in tool strip item collection, 
        /// given dark mode is enabled or not.
        /// </summary>
        /// <param name="toolStripItemCollection">The tool strip item collection</param>
        internal static void SetColorsOfToolStripItemCollection
            (ToolStripItemCollection toolStripItemCollection)
        {
            foreach (ToolStripItem toolStripItem in toolStripItemCollection)
            {
                SetColorsOfToolStripItem(toolStripItem);
            }
        }

        /// <summary>
        /// Set the colors of the constructor, given dark mode is enabled or not.
        /// </summary>
        /// <param name="parentObject">The parent object</param>
        public static void SetColorsOfConstructor(object parentObject)
        {
            if (!(parentObject is Form))
            {
                return;
            }

            (parentObject as Form).BackColor = BackColor;
            (parentObject as Form).ForeColor = ForeColor;
        }

        /// <summary>
        /// Set the colors of every control, given dark mode is enabled or not.
        /// </summary>
        /// <param name="controlCollection">The control collection</param>
        public static void SetColorsOfControlCollection
            (Control.ControlCollection controlCollection)
        {
            if (controlCollection.Count == 0)
            {
                return;
            }

            foreach (var control in controlCollection)
            {
                (control as Control).BackColor = BackColor;
                (control as Control).ForeColor = ForeColor;

                if (control is Control.ControlCollection)
                {
                    SetColorsOfControlCollection
                        (control as Control.ControlCollection);
                }

                SetColorsOfControlCollection((control as Control).Controls);
            }
        }

        /// <summary>
        /// Set the colors of every tool strip item in list, 
        /// given dark mode is enabled or not.
        /// </summary>
        /// <param name="toolStripItemList">The tool strip item list</param>
        public static void SetColorsOfToolStripItemList
            (List<ToolStripItem> toolStripItemList)
        {
            toolStripItemList.ForEach(toolStripItem =>
            {
                SetColorsOfToolStripItem(toolStripItem);
            });
        }

        /// <summary>
        /// Set the colors of every tool strip menu item in list, 
        /// given dark mode is enabled or not.
        /// </summary>
        /// <param name="toolStripMenuItemList">The tool strip menu item list</param>
        public static void SetColorsOfToolStripItemList
            (List<ToolStripMenuItem> toolStripMenuItemList)
        {
            toolStripMenuItemList.ForEach(toolStripMenuItem =>
            {
                SetColorsOfToolStripItem(toolStripMenuItem);
            });
        }

        #endregion
    }
}