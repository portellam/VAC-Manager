using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deviceAddToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceAddConfirmToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceAddSelectAllToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deviceAddSelectToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceAddSelectWaveInToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceAddSelectWaveOutToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deviceReloadAllToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceRemoveAllLinkedToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deviceRemoveAllToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceRemoveAllUnlinkedToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deviceRemoveToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceRemoveWaveInToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            deviceRemoveWaveOutToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveACopyAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkAddWaveInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkAddWaveOutToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkDefaultBitRateToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkDefaultBufferToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkDefaultChannelsToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkDefaultPrefillToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkDefaultResyncAtToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkDefaultSamplingRateToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem linkRemoveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkRemoveToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkRemoveWaveInToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            linkRemoveWaveOutToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem linkToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            repeaterRestartAllToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem repeaterRestartToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            repeaterStartAllToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem repeaterStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeaterStopAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeaterStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeaterToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem
            viewToggleDarkModeToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator deviceToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator deviceToolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator fileToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator linkToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator linkToolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator repeaterToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator repeaterToolStripSeparator2;
        private TableLayoutPanel gridTableLayoutPanel;
        private ToolStripRenderer initialMenuStrip1Renderer;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [ExcludeFromCodeCoverage]
        internal void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();

            this.deviceAddToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceAddConfirmToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceAddSelectAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceAddSelectToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceAddSelectWaveInToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceAddSelectWaveOutToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceReloadAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceRemoveAllLinkedToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceRemoveAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceRemoveAllUnlinkedToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceRemoveToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceRemoveWaveInToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceRemoveWaveOutToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.deviceToolStripSeparator1 =
                new System.Windows.Forms.ToolStripSeparator();

            this.deviceToolStripSeparator2 =
                new System.Windows.Forms.ToolStripSeparator();

            this.fileCloseToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileExitToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileNewToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileOpenToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileSaveACopyAsToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileSaveAsToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileSaveToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.fileToolStripSeparator1 =
                new System.Windows.Forms.ToolStripSeparator();

            this.gridTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();

            this.helpAboutToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.linkAddToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkAddWaveInToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkAddWaveOutToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkDefaultBitRateToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkDefaultBufferToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkDefaultChannelsToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkDefaultPrefillToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkDefaultResyncAtToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkDefaultSamplingRateToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkRemoveAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkRemoveToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkRemoveWaveInToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkRemoveWaveOutToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.linkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.linkToolStripSeparator1 =
                new System.Windows.Forms.ToolStripSeparator();

            this.linkToolStripSeparator2 =
                new System.Windows.Forms.ToolStripSeparator();

            this.repeaterRestartAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterRestartToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterStartAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterStartToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterStopAllToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterStopToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.repeaterToolStripSeparator1 =
                new System.Windows.Forms.ToolStripSeparator();

            this.repeaterToolStripSeparator2 =
                new System.Windows.Forms.ToolStripSeparator();

            this.viewToggleDarkModeToolStripMenuItem =
                new System.Windows.Forms.ToolStripMenuItem();

            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.fileToolStripMenuItem,
                this.deviceToolStripMenuItem,
                this.linkToolStripMenuItem,
                this.repeaterToolStripMenuItem,
                this.viewToolStripMenuItem,
                this.helpToolStripMenuItem
            });

            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.deviceReloadAllToolStripMenuItem,
                    this.deviceToolStripSeparator1,
                    this.deviceAddToolStripMenuItem,
                    this.deviceToolStripSeparator2,
                    this.deviceRemoveToolStripMenuItem,
                    this.deviceRemoveAllToolStripMenuItem,
                    this.deviceRemoveAllLinkedToolStripMenuItem,
                    this.deviceRemoveAllUnlinkedToolStripMenuItem
                });

            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";

            this.deviceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));

            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.deviceToolStripMenuItem.Text = "Device";
            this.deviceToolStripMenuItem.DropDown.AutoClose = false;
            //
            // deviceAddToolStripMenuItem
            //
            this.deviceAddToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.deviceAddConfirmToolStripMenuItem,
                    this.deviceAddSelectToolStripMenuItem,
                    this.deviceAddSelectAllToolStripMenuItem,
                });

            this.deviceAddToolStripMenuItem.Name = "deviceAddToolStripMenuItem";
            this.deviceAddToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.deviceAddToolStripMenuItem.Text = "Add...";
            //
            // deviceAddConfirmToolStripMenuItem
            //
            this.deviceAddConfirmToolStripMenuItem.Name =
                "deviceAddConfirmToolStripMenuItem";

            this.deviceAddConfirmToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceAddConfirmToolStripMenuItem.Text = "Confirm Selected";
            // 
            // deviceAddSelectToolStripMenuItem
            // 
            this.deviceAddSelectToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.deviceAddSelectWaveInToolStripMenuItem,
                    this.deviceAddSelectWaveOutToolStripMenuItem
                });

            this.deviceAddSelectToolStripMenuItem.Name =
                "deviceAddSelectToolStripMenuItem";

            this.deviceAddSelectToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceAddSelectToolStripMenuItem.Text = "Select...";
            // 
            // deviceAddSelectWaveInToolStripMenuItem
            // 
            this.deviceAddSelectWaveInToolStripMenuItem.Name =
                "deviceAddSelectWaveInToolStripMenuItem";

            this.deviceAddSelectWaveInToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.deviceAddSelectWaveInToolStripMenuItem.Tag = "";
            this.deviceAddSelectWaveInToolStripMenuItem.Text = WaveInAsString;
            // 
            // deviceAddSelectWaveOutToolStripMenuItem
            // 
            this.deviceAddSelectWaveOutToolStripMenuItem.Name =
                "deviceAddSelectWaveOutToolStripMenuItem";

            this.deviceAddSelectWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.deviceAddSelectWaveOutToolStripMenuItem.Tag = "";
            this.deviceAddSelectWaveOutToolStripMenuItem.Text = WaveOutAsString;
            // 
            // deviceAddAllToolStripMenuItem
            // 
            this.deviceAddSelectAllToolStripMenuItem.Name =
                "deviceAddAllToolStripMenuItem";

            this.deviceAddSelectAllToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceAddSelectAllToolStripMenuItem.Tag = "";
            this.deviceAddSelectAllToolStripMenuItem.Text = "Select All";
            // 
            // deviceReloadAllToolStripMenuItem
            // 
            this.deviceReloadAllToolStripMenuItem.Name =
                "deviceReloadAllToolStripMenuItem";

            this.deviceReloadAllToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceReloadAllToolStripMenuItem.Tag = "";
            this.deviceReloadAllToolStripMenuItem.Text = "Force Reload All";
            // 
            // deviceRemoveToolStripMenuItem
            // 
            this.deviceRemoveToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.deviceRemoveWaveInToolStripMenuItem,
                    this.deviceRemoveWaveOutToolStripMenuItem
                });

            this.deviceRemoveToolStripMenuItem.Name = "deviceRemoveToolStripMenuItem";
            this.deviceRemoveToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.deviceRemoveToolStripMenuItem.Text = "Remove...";
            // 
            // deviceRemoveAllToolStripMenuItem
            // 
            this.deviceRemoveAllToolStripMenuItem.Name =
                "deviceRemoveAllToolStripMenuItem";

            this.deviceRemoveAllToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceRemoveAllToolStripMenuItem.Tag = "";
            this.deviceRemoveAllToolStripMenuItem.Text = "Remove All";
            // 
            // deviceRemoveAllLinkedToolStripMenuItem
            // 
            this.deviceRemoveAllLinkedToolStripMenuItem.Name =
                "deviceRemoveAllLinkedToolStripMenuItem";

            this.deviceRemoveAllLinkedToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceRemoveAllLinkedToolStripMenuItem.Tag = "";
            this.deviceRemoveAllLinkedToolStripMenuItem.Text = "Remove All Linked";
            // 
            // deviceRemoveAllUnlinkedToolStripMenuItem
            // 
            this.deviceRemoveAllUnlinkedToolStripMenuItem.Name =
                "deviceRemoveAllUnlinkedToolStripMenuItem";

            this.deviceRemoveAllUnlinkedToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceRemoveAllUnlinkedToolStripMenuItem.Tag = "";
            this.deviceRemoveAllUnlinkedToolStripMenuItem.Text = "Remove All Unlinked";
            // 
            // deviceRemoveWaveInToolStripMenuItem
            // 
            this.deviceRemoveWaveInToolStripMenuItem.Name =
                "deviceRemoveWaveInToolStripMenuItem";

            this.deviceRemoveWaveInToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.deviceRemoveWaveInToolStripMenuItem.Tag = "";
            this.deviceRemoveWaveInToolStripMenuItem.Text = WaveInAsString;
            // 
            // deviceRemoveWaveOutToolStripMenuItem
            // 
            this.deviceRemoveWaveOutToolStripMenuItem.Name =
                "deviceRemoveWaveOutToolStripMenuItem";

            this.deviceRemoveWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.deviceRemoveWaveOutToolStripMenuItem.Tag = "";
            this.deviceRemoveWaveOutToolStripMenuItem.Text = WaveOutAsString;
            // 
            // deviceToolStripSeparator1
            // 
            this.deviceToolStripSeparator1.Name = "deviceToolStripSeparator1";
            this.deviceToolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // deviceToolStripSeparator2
            // 
            this.deviceToolStripSeparator2.Name = "deviceToolStripSeparator2";
            this.deviceToolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.fileNewToolStripMenuItem,
                    this.fileOpenToolStripMenuItem,
                    this.fileSaveToolStripMenuItem,
                    this.fileSaveAsToolStripMenuItem,
                    this.fileSaveACopyAsToolStripMenuItem,
                    this.fileCloseToolStripMenuItem,
                    this.fileToolStripSeparator1,
                    this.fileExitToolStripMenuItem
                });

            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";

            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));

            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileCloseToolStripMenuItem
            // 
            this.fileCloseToolStripMenuItem.Name = "fileCloseToolStripMenuItem";

            this.fileCloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));

            this.fileCloseToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileCloseToolStripMenuItem.Text = "Close";
            // 
            // fileExitToolStripMenuItem
            // 
            this.fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";

            this.fileExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));

            this.fileExitToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileExitToolStripMenuItem.Text = "Exit";
            // 
            // fileNewToolStripMenuItem
            // 
            this.fileNewToolStripMenuItem.Name = "fileNewToolStripMenuItem";

            this.fileNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));

            this.fileNewToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileNewToolStripMenuItem.Text = "New";
            // 
            // fileOpenToolStripMenuItem
            // 
            this.fileOpenToolStripMenuItem.Name = "fileOpenToolStripMenuItem";

            this.fileOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));

            this.fileOpenToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileOpenToolStripMenuItem.Text = "Open...";
            // 
            // fileSaveToolStripMenuItem
            // 
            this.fileSaveToolStripMenuItem.Name = "fileSaveToolStripMenuItem";

            this.fileSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));

            this.fileSaveToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileSaveToolStripMenuItem.Text = "Save";
            // 
            // fileSaveAsToolStripMenuItem
            // 
            this.fileSaveAsToolStripMenuItem.Name = "fileSaveAsToolStripMenuItem";

            this.fileSaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                | System.Windows.Forms.Keys.S)));

            this.fileSaveAsToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileSaveAsToolStripMenuItem.Text = "Save As...";
            // 
            // fileSaveACopyAsToolStripMenuItem
            // 
            this.fileSaveACopyAsToolStripMenuItem.Name =
                "fileSaveACopyAsToolStripMenuItem";

            this.fileSaveACopyAsToolStripMenuItem.Size =
                new System.Drawing.Size(231, 26);

            this.fileSaveACopyAsToolStripMenuItem.Text = "Save a Copy As...";
            // 
            // fileToolStripSeparator1
            // 
            this.fileToolStripSeparator1.Name = "fileToolStripSeparator1";
            this.fileToolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // linkToolStripMenuItem
            // 
            this.linkToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.linkAddToolStripMenuItem,
                    this.linkToolStripSeparator1,
                    this.linkRemoveToolStripMenuItem,
                    this.linkRemoveAllToolStripMenuItem,
                    this.linkToolStripSeparator2,
                    this.linkDefaultBitRateToolStripMenuItem,
                    this.linkDefaultBufferToolStripMenuItem,
                    this.linkDefaultChannelsToolStripMenuItem,
                    this.linkDefaultPrefillToolStripMenuItem,
                    this.linkDefaultResyncAtToolStripMenuItem,
                    this.linkDefaultSamplingRateToolStripMenuItem
                });

            this.linkToolStripMenuItem.Name = "linkToolStripMenuItem";

            this.linkToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));

            this.linkToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.linkToolStripMenuItem.Text = "Link";
            // 
            // linkAddToolStripMenuItem
            // 
            this.linkAddToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.linkAddWaveInToolStripMenuItem,
                    this.linkAddWaveOutToolStripMenuItem
                });

            this.linkAddToolStripMenuItem.Name = "linkAddToolStripMenuItem";
            this.linkAddToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.linkAddToolStripMenuItem.Text = "Link...";
            // 
            // linkAddWaveInToolStripMenuItem
            // 
            this.linkAddWaveInToolStripMenuItem.Name = "linkAddWaveInToolStripMenuItem";
            this.linkAddWaveInToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.linkAddWaveInToolStripMenuItem.Tag = "";
            this.linkAddWaveInToolStripMenuItem.Text = WaveInAsString;
            // 
            // linkAddWaveOutToolStripMenuItem
            // 
            this.linkAddWaveOutToolStripMenuItem.Name =
                "linkAddWaveOutToolStripMenuItem";

            this.linkAddWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.linkAddWaveOutToolStripMenuItem.Tag = "";
            this.linkAddWaveOutToolStripMenuItem.Text = WaveOutAsString;
            // 
            // linkRemoveToolStripMenuItem
            // 
            this.linkRemoveToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.linkRemoveWaveInToolStripMenuItem,
                    this.linkRemoveWaveOutToolStripMenuItem
                });

            this.linkRemoveToolStripMenuItem.Name = "linkRemoveToolStripMenuItem";
            this.linkRemoveToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.linkRemoveToolStripMenuItem.Text = "Unlink...";
            // 
            // linkRemoveAllToolStripMenuItem
            // 
            this.linkRemoveAllToolStripMenuItem.Name = "linkRemoveAllToolStripMenuItem";
            this.linkRemoveAllToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.linkRemoveAllToolStripMenuItem.Tag = "";
            this.linkRemoveAllToolStripMenuItem.Text = "Unlink All";
            // 
            // 
            // linkRemoveWaveInToolStripMenuItem
            // 
            this.linkRemoveWaveInToolStripMenuItem.Name =
                "linkRemoveWaveInToolStripMenuItem";

            this.linkRemoveWaveInToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.linkRemoveWaveInToolStripMenuItem.Tag = "";
            this.linkRemoveWaveInToolStripMenuItem.Text = WaveInAsString;
            // 
            // linkRemoveWaveOutToolStripMenuItem
            // 
            this.linkRemoveWaveOutToolStripMenuItem.Name =
                "linkRemoveWaveOutToolStripMenuItem";

            this.linkRemoveWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.linkRemoveWaveOutToolStripMenuItem.Tag = "";
            this.linkRemoveWaveOutToolStripMenuItem.Text = WaveOutAsString;
            // 
            // linkDefaultBitRateToolStripMenuItem
            // 
            this.linkDefaultBitRateToolStripMenuItem.Name =
                "DefaultBitRateToolStripMenuItem";

            this.linkDefaultBitRateToolStripMenuItem.Size =
                new System.Drawing.Size(285, 26);

            this.linkDefaultBitRateToolStripMenuItem.Tag = "";
            this.linkDefaultBitRateToolStripMenuItem.Text =
                "Default Bit Rate (Bit/Sample)";
            // 
            // linkDefaultBufferToolStripMenuItem
            // 
            this.linkDefaultBufferToolStripMenuItem.Name =
                "DefaultBufferToolStripMenuItem";

            this.linkDefaultBufferToolStripMenuItem.Size =
                new System.Drawing.Size(285, 26);

            this.linkDefaultBufferToolStripMenuItem.Tag = "";
            this.linkDefaultBufferToolStripMenuItem.Text = "Default Buffer (ms)";
            // 
            // linkDefaultChannelsToolStripMenuItem
            // 
            this.linkDefaultChannelsToolStripMenuItem.Name =
                "DefaultChannelsToolStripMenuItem";

            this.linkDefaultChannelsToolStripMenuItem.Size =
                new System.Drawing.Size(285, 26);

            this.linkDefaultChannelsToolStripMenuItem.Tag = "";
            this.linkDefaultChannelsToolStripMenuItem.Text = "Default Channels";
            // 
            // linkDefaultPrefillToolStripMenuItem
            // 
            this.linkDefaultPrefillToolStripMenuItem.Name =
                "DefaultPrefillToolStripMenuItem";

            this.linkDefaultPrefillToolStripMenuItem.Size =
                new System.Drawing.Size(285, 26);

            this.linkDefaultPrefillToolStripMenuItem.Tag = "";
            this.linkDefaultPrefillToolStripMenuItem.Text = "Default Prefill (%)";
            // 
            // linkDefaultResyncAtToolStripMenuItem
            // 
            this.linkDefaultResyncAtToolStripMenuItem.Name =
                "DefaultResyncAtToolStripMenuItem";

            this.linkDefaultResyncAtToolStripMenuItem.Size =
                new System.Drawing.Size(285, 26);

            this.linkDefaultResyncAtToolStripMenuItem.Tag = "";

            this.linkDefaultResyncAtToolStripMenuItem.Text =
                "Default Resync At (%)";
            // 
            // linkDefaultSamplingRateToolStripMenuItem
            // 
            this.linkDefaultSamplingRateToolStripMenuItem.Name =
                "DefaultSamplingRateToolStripMenuItem";

            this.linkDefaultSamplingRateToolStripMenuItem.Size =
                new System.Drawing.Size(285, 26);

            this.linkDefaultSamplingRateToolStripMenuItem.Tag = "";

            this.linkDefaultSamplingRateToolStripMenuItem.Text =
                "Default Sampling Rate (Hz)";
            // 
            // linkToolStripSeparator1
            // 
            this.linkToolStripSeparator1.Name = "linkToolStripSeparator1";
            this.linkToolStripSeparator1.Size = new System.Drawing.Size(282, 6);
            // linkToolStripSeparator2
            // 
            this.linkToolStripSeparator2.Name = "linkToolStripSeparator2";
            this.linkToolStripSeparator2.Size = new System.Drawing.Size(282, 6);
            // 
            // repeaterToolStripMenuItem
            // 
            this.repeaterToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.repeaterRestartToolStripMenuItem,
                    this.repeaterRestartAllToolStripMenuItem,
                    this.repeaterToolStripSeparator1,
                    this.repeaterStartToolStripMenuItem,
                    this.repeaterStartAllToolStripMenuItem,
                    this.repeaterToolStripSeparator2,
                    this.repeaterStopToolStripMenuItem,
                    this.repeaterStopAllToolStripMenuItem
                });

            this.repeaterToolStripMenuItem.Name = "repeaterToolStripMenuItem";

            this.repeaterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));

            this.repeaterToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.repeaterToolStripMenuItem.Text = "Repeater";
            // 
            // repeaterRestartAllToolStripMenuItem
            // 
            this.repeaterRestartAllToolStripMenuItem.Name =
                "repeaterRestartAllToolStripMenuItem";

            this.repeaterRestartAllToolStripMenuItem.Size =
                new System.Drawing.Size(224, 26);

            this.repeaterRestartAllToolStripMenuItem.Tag = "";
            this.repeaterRestartAllToolStripMenuItem.Text = "Restart All";
            // 
            // repeaterRestartToolStripMenuItem
            // 
            this.repeaterRestartToolStripMenuItem.Name =
                "repeaterRestartToolStripMenuItem";

            this.repeaterRestartToolStripMenuItem.Size =
                new System.Drawing.Size(224, 26);

            this.repeaterRestartToolStripMenuItem.Tag = "";
            this.repeaterRestartToolStripMenuItem.Text = "Restart...";
            // 
            // repeaterStartAllToolStripMenuItem
            // 
            this.repeaterStartAllToolStripMenuItem.CheckOnClick = true;

            this.repeaterStartAllToolStripMenuItem.Name =
                "repeaterStartAllToolStripMenuItem";

            this.repeaterStartAllToolStripMenuItem.Size =
                new System.Drawing.Size(224, 26);

            this.repeaterStartAllToolStripMenuItem.Tag = "";
            this.repeaterStartAllToolStripMenuItem.Text = "Start All";
            // 
            // repeaterStartToolStripMenuItem
            // 
            this.repeaterStartToolStripMenuItem.CheckOnClick = true;
            this.repeaterStartToolStripMenuItem.Name = "repeaterStartToolStripMenuItem";
            this.repeaterStartToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.repeaterStartToolStripMenuItem.Tag = "";
            this.repeaterStartToolStripMenuItem.Text = "Start...";
            // 
            // repeaterStopToolStripMenuItem
            // 
            this.repeaterStopToolStripMenuItem.CheckOnClick = true;

            this.repeaterStopToolStripMenuItem.Name = "repeaterStopToolStripMenuItem";

            this.repeaterStopToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.repeaterStopToolStripMenuItem.Tag = "";
            this.repeaterStopToolStripMenuItem.Text = "Stop...";
            // 
            // repeaterStopAllToolStripMenuItem
            // 
            this.repeaterStopAllToolStripMenuItem.CheckOnClick = true;

            this.repeaterStopAllToolStripMenuItem.Name =
                "repeaterStopAllToolStripMenuItem";

            this.repeaterStopAllToolStripMenuItem.Size =
                new System.Drawing.Size(224, 26);

            this.repeaterStopAllToolStripMenuItem.Tag = "";
            this.repeaterStopAllToolStripMenuItem.Text = "Stop All";
            // 
            // repeaterToolStripSeparator1
            // 
            this.repeaterToolStripSeparator1.Name = "repeaterToolStripSeparator1";
            this.repeaterToolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // repeaterToolStripSeparator2
            // 
            this.repeaterToolStripSeparator2.Name = "repeaterToolStripSeparator2";
            this.repeaterToolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // gridTableLayoutPanel
            // 
            this.gridTableLayoutPanel.AutoScroll = true;
            this.gridTableLayoutPanel.AutoSize = true;
            this.gridTableLayoutPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridTableLayoutPanel.ColumnCount = 2;

            this.gridTableLayoutPanel.ColumnStyles.Add
                (new System.Windows.Forms.ColumnStyle
                    (System.Windows.Forms.SizeType.Percent, 50F));

            this.gridTableLayoutPanel.ColumnStyles.Add
                (new System.Windows.Forms.ColumnStyle
                    (System.Windows.Forms.SizeType.Percent, 50F));

            this.gridTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;

            this.gridTableLayoutPanel.GrowStyle =
                System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;

            this.gridTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.gridTableLayoutPanel.Name = "gridTableLayoutPanel";
            this.gridTableLayoutPanel.RowCount = 2;

            this.gridTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Percent, 50F));

            this.gridTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle
                (System.Windows.Forms.SizeType.Percent, 50F));

            this.gridTableLayoutPanel.Size = new System.Drawing.Size(620, 385);
            this.gridTableLayoutPanel.TabIndex = 0;
            this.gridTableLayoutPanel.TabStop = true;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.helpAboutToolStripMenuItem
                });

            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";

            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));

            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);

            this.helpAboutToolStripMenuItem.Text =
                $"About {Common.ApplicationNameAsAbbreviation}";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems
                .AddRange(new System.Windows.Forms.ToolStripItem[]
                {
                    this.viewToggleDarkModeToolStripMenuItem
                });

            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";

            this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)
                ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));

            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewToggleDarkModeToolStripMenuItem
            // 
            this.viewToggleDarkModeToolStripMenuItem.CheckOnClick = true;

            this.viewToggleDarkModeToolStripMenuItem.Name =
                "viewToggleDarkModeToolStripMenuItem";

            this.viewToggleDarkModeToolStripMenuItem.Size =
                new System.Drawing.Size(83, 26);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(622, 433);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}