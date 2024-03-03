﻿using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace VACM.NET4_0.Views
{
    public partial class MainForm
    {
        #region Windows Form Designer generated parameters

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        private BackgroundWorker backgroundWorker1;
        private MenuStrip menuStrip1;
        private TableLayoutPanel gridTableLayoutPanel;
        private ToolStripMenuItem deviceAddConfirmToolStripMenuItem;
        private ToolStripMenuItem deviceAddSelectAllToolStripMenuItem;
        private ToolStripMenuItem deviceAddSelectToolStripMenuItem;
        private ToolStripMenuItem deviceAddSelectWaveInToolStripMenuItem;
        private ToolStripMenuItem deviceAddSelectWaveOutToolStripMenuItem;
        private ToolStripMenuItem deviceAddToolStripMenuItem;
        private ToolStripMenuItem deviceReloadAllToolStripMenuItem;
        private ToolStripMenuItem deviceRemoveAllLinkedToolStripMenuItem;
        private ToolStripMenuItem deviceRemoveAllToolStripMenuItem;
        private ToolStripMenuItem deviceRemoveAllUnlinkedToolStripMenuItem;
        private ToolStripMenuItem deviceRemoveToolStripMenuItem;
        private ToolStripMenuItem deviceRemoveWaveInToolStripMenuItem;
        private ToolStripMenuItem deviceRemoveWaveOutToolStripMenuItem;
        private ToolStripMenuItem deviceToolStripMenuItem;
        private ToolStripMenuItem fileCloseToolStripMenuItem;
        private ToolStripMenuItem fileExitToolStripMenuItem;
        private ToolStripMenuItem fileNewToolStripMenuItem;
        private ToolStripMenuItem fileOpenToolStripMenuItem;
        private ToolStripMenuItem fileSaveACopyAsToolStripMenuItem;
        private ToolStripMenuItem fileSaveAsToolStripMenuItem;
        private ToolStripMenuItem fileSaveToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpAboutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem linkAddToolStripMenuItem;
        private ToolStripMenuItem linkAddWaveInToolStripMenuItem;
        private ToolStripMenuItem linkAddWaveOutToolStripMenuItem;
        private ToolStripMenuItem linkDefaultBitRateToolStripMenuItem;
        private ToolStripMenuItem linkDefaultBufferToolStripMenuItem;
        private ToolStripMenuItem linkDefaultChannelsToolStripMenuItem;
        private ToolStripMenuItem linkDefaultPrefillToolStripMenuItem;
        private ToolStripMenuItem linkDefaultResyncAtToolStripMenuItem;
        private ToolStripMenuItem linkDefaultSamplingRateToolStripMenuItem;
        private ToolStripMenuItem linkRemoveAllToolStripMenuItem;
        private ToolStripMenuItem linkRemoveToolStripMenuItem;
        private ToolStripMenuItem linkRemoveWaveInToolStripMenuItem;
        private ToolStripMenuItem linkRemoveWaveOutToolStripMenuItem;
        private ToolStripMenuItem linkToolStripMenuItem;
        private ToolStripMenuItem repeaterRestartAllToolStripMenuItem;
        private ToolStripMenuItem repeaterRestartToolStripMenuItem;
        private ToolStripMenuItem repeaterStartAllToolStripMenuItem;
        private ToolStripMenuItem repeaterStartToolStripMenuItem;
        private ToolStripMenuItem repeaterStopAllToolStripMenuItem;
        private ToolStripMenuItem repeaterStopToolStripMenuItem;
        private ToolStripMenuItem repeaterToolStripMenuItem;
        private ToolStripMenuItem viewToggleDarkModeToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripRenderer initialMenuStrip1Renderer;
        private ToolStripSeparator deviceToolStripSeparator1;
        private ToolStripSeparator deviceToolStripSeparator2;
        private ToolStripSeparator fileToolStripSeparator1;
        private ToolStripSeparator linkToolStripSeparator1;
        private ToolStripSeparator linkToolStripSeparator2;
        private ToolStripSeparator repeaterToolStripSeparator1;
        private ToolStripSeparator repeaterToolStripSeparator2;
        private Manina.Windows.Forms.TabControl tabControl1;
        private Manina.Windows.Forms.Tab gridTab;
        private Manina.Windows.Forms.Tab graphTab;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [ExcludeFromCodeCoverage]
        internal void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.deviceAddConfirmToolStripMenuItem = new ToolStripMenuItem();
            this.deviceAddSelectAllToolStripMenuItem = new ToolStripMenuItem();
            this.deviceAddSelectToolStripMenuItem = new ToolStripMenuItem();
            this.deviceAddSelectWaveInToolStripMenuItem = new ToolStripMenuItem();
            this.deviceAddSelectWaveOutToolStripMenuItem = new ToolStripMenuItem();
            this.deviceAddToolStripMenuItem = new ToolStripMenuItem();
            this.deviceReloadAllToolStripMenuItem = new ToolStripMenuItem();
            this.deviceRemoveAllLinkedToolStripMenuItem = new ToolStripMenuItem();
            this.deviceRemoveAllToolStripMenuItem = new ToolStripMenuItem();
            this.deviceRemoveAllUnlinkedToolStripMenuItem = new ToolStripMenuItem();
            this.deviceRemoveToolStripMenuItem = new ToolStripMenuItem();
            this.deviceRemoveWaveInToolStripMenuItem = new ToolStripMenuItem();
            this.deviceRemoveWaveOutToolStripMenuItem = new ToolStripMenuItem();
            this.deviceToolStripMenuItem = new ToolStripMenuItem();
            this.deviceToolStripSeparator1 = new ToolStripSeparator();
            this.deviceToolStripSeparator2 = new ToolStripSeparator();
            this.fileCloseToolStripMenuItem = new ToolStripMenuItem();
            this.fileExitToolStripMenuItem = new ToolStripMenuItem();
            this.fileNewToolStripMenuItem = new ToolStripMenuItem();
            this.fileOpenToolStripMenuItem = new ToolStripMenuItem();
            this.fileSaveACopyAsToolStripMenuItem = new ToolStripMenuItem();
            this.fileSaveAsToolStripMenuItem = new ToolStripMenuItem();
            this.fileSaveToolStripMenuItem = new ToolStripMenuItem();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.fileToolStripSeparator1 = new ToolStripSeparator();
            this.graphTab = new Manina.Windows.Forms.Tab();
            this.gridTab = new Manina.Windows.Forms.Tab();
            this.gridTableLayoutPanel = new TableLayoutPanel();
            this.helpAboutToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.linkAddToolStripMenuItem = new ToolStripMenuItem();
            this.linkAddWaveInToolStripMenuItem = new ToolStripMenuItem();
            this.linkAddWaveOutToolStripMenuItem = new ToolStripMenuItem();
            this.linkDefaultBitRateToolStripMenuItem = new ToolStripMenuItem();
            this.linkDefaultBufferToolStripMenuItem = new ToolStripMenuItem();
            this.linkDefaultChannelsToolStripMenuItem = new ToolStripMenuItem();
            this.linkDefaultPrefillToolStripMenuItem = new ToolStripMenuItem();
            this.linkDefaultResyncAtToolStripMenuItem = new ToolStripMenuItem();
            this.linkDefaultSamplingRateToolStripMenuItem = new ToolStripMenuItem();
            this.linkRemoveAllToolStripMenuItem = new ToolStripMenuItem();
            this.linkRemoveToolStripMenuItem = new ToolStripMenuItem();
            this.linkRemoveWaveInToolStripMenuItem = new ToolStripMenuItem();
            this.linkRemoveWaveOutToolStripMenuItem = new ToolStripMenuItem();
            this.linkToolStripMenuItem = new ToolStripMenuItem();
            this.linkToolStripSeparator1 = new ToolStripSeparator();
            this.linkToolStripSeparator2 = new ToolStripSeparator();
            this.repeaterRestartAllToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterRestartToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterStartAllToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterStartToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterStopAllToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterStopToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterToolStripMenuItem = new ToolStripMenuItem();
            this.repeaterToolStripSeparator1 = new ToolStripSeparator();
            this.repeaterToolStripSeparator2 = new ToolStripSeparator();
            this.tabControl1 = new Manina.Windows.Forms.TabControl();
            this.viewToggleDarkModeToolStripMenuItem = new ToolStripMenuItem();
            this.viewToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gridTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);

            this.menuStrip1.Items.AddRange(new ToolStripItem[]
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
                .AddRange(new ToolStripItem[]
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

            this.deviceToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.D)));

            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.deviceToolStripMenuItem.Text = "Device";
            this.deviceToolStripMenuItem.DropDown.AutoClose = false;
            //
            // deviceAddToolStripMenuItem
            //
            this.deviceAddToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
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

            this.deviceAddConfirmToolStripMenuItem.Click += new System.EventHandler
                (this.deviceAddConfirmToolStripMenuItem_Click);
            // 
            // deviceAddSelectToolStripMenuItem
            // 
            this.deviceAddSelectToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
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
            // 
            // deviceAddSelectWaveOutToolStripMenuItem
            // 
            this.deviceAddSelectWaveOutToolStripMenuItem.Name =
                "deviceAddSelectWaveOutToolStripMenuItem";

            this.deviceAddSelectWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.deviceAddSelectWaveOutToolStripMenuItem.Tag = "";
            // 
            // deviceAddAllToolStripMenuItem
            // 
            this.deviceAddSelectAllToolStripMenuItem.Name =
                "deviceAddAllToolStripMenuItem";

            this.deviceAddSelectAllToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceAddSelectAllToolStripMenuItem.Tag = "";
            this.deviceAddSelectAllToolStripMenuItem.Text = "Select All";

            this.deviceAddSelectAllToolStripMenuItem.Click += new System.EventHandler
                (this.deviceAddSelectAllToolStripMenuItem_Click);
            // 
            // deviceReloadAllToolStripMenuItem
            // 
            this.deviceReloadAllToolStripMenuItem.Name =
                "deviceReloadAllToolStripMenuItem";

            this.deviceReloadAllToolStripMenuItem.Size =
                new System.Drawing.Size(230, 26);

            this.deviceReloadAllToolStripMenuItem.Tag = "";
            this.deviceReloadAllToolStripMenuItem.Text = "Force Reload All";

            this.deviceReloadAllToolStripMenuItem.Click +=
                new System.EventHandler(this.deviceReloadAllToolStripMenuItem_Click);
            // 
            // deviceRemoveToolStripMenuItem
            // 
            this.deviceRemoveToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
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
            // 
            // deviceRemoveWaveOutToolStripMenuItem
            // 
            this.deviceRemoveWaveOutToolStripMenuItem.Name =
                "deviceRemoveWaveOutToolStripMenuItem";

            this.deviceRemoveWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.deviceRemoveWaveOutToolStripMenuItem.Tag = "";
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
                .AddRange(new ToolStripItem[]
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

            this.fileToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.F)));

            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileCloseToolStripMenuItem
            // 
            this.fileCloseToolStripMenuItem.Name = "fileCloseToolStripMenuItem";

            this.fileCloseToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Control | Keys.W)));

            this.fileCloseToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileCloseToolStripMenuItem.Text = "Close";
            // 
            // fileExitToolStripMenuItem
            // 
            this.fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";

            this.fileExitToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.F4)));

            this.fileExitToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileExitToolStripMenuItem.Text = "Exit";

            this.fileExitToolStripMenuItem.Click +=
                new System.EventHandler(this.fileExitToolStripMenuItem_Click);
            // 
            // fileNewToolStripMenuItem
            // 
            this.fileNewToolStripMenuItem.Name = "fileNewToolStripMenuItem";

            this.fileNewToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Control | Keys.N)));

            this.fileNewToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileNewToolStripMenuItem.Text = "New";
            // 
            // fileOpenToolStripMenuItem
            // 
            this.fileOpenToolStripMenuItem.Name = "fileOpenToolStripMenuItem";

            this.fileOpenToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Control | Keys.O)));

            this.fileOpenToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileOpenToolStripMenuItem.Text = "Open...";

            this.fileOpenToolStripMenuItem.Click +=
                new System.EventHandler(this.fileOpenToolStripMenuItem_Click);
            // 
            // fileSaveToolStripMenuItem
            // 
            this.fileSaveToolStripMenuItem.Name = "fileSaveToolStripMenuItem";

            this.fileSaveToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Control | Keys.S)));

            this.fileSaveToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fileSaveToolStripMenuItem.Text = "Save";
            // 
            // fileSaveAsToolStripMenuItem
            // 
            this.fileSaveAsToolStripMenuItem.Name = "fileSaveAsToolStripMenuItem";

            this.fileSaveAsToolStripMenuItem.ShortcutKeys = ((Keys)
                (((Keys.Control | Keys.Alt)
                | Keys.S)));

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
                .AddRange(new ToolStripItem[]
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

            this.linkToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.L)));

            this.linkToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.linkToolStripMenuItem.Text = "Link";
            // 
            // linkAddToolStripMenuItem
            // 
            this.linkAddToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
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
            // 
            // linkAddWaveOutToolStripMenuItem
            // 
            this.linkAddWaveOutToolStripMenuItem.Name =
                "linkAddWaveOutToolStripMenuItem";

            this.linkAddWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.linkAddWaveOutToolStripMenuItem.Tag = "";
            // 
            // linkRemoveToolStripMenuItem
            // 
            this.linkRemoveToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
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
            // 
            // linkRemoveWaveOutToolStripMenuItem
            // 
            this.linkRemoveWaveOutToolStripMenuItem.Name =
                "linkRemoveWaveOutToolStripMenuItem";

            this.linkRemoveWaveOutToolStripMenuItem.Size =
                new System.Drawing.Size(156, 26);

            this.linkRemoveWaveOutToolStripMenuItem.Tag = "";
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
                .AddRange(new ToolStripItem[]
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

            this.repeaterToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.R)));

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
            // graphTab
            // 
            this.graphTab.Location = new System.Drawing.Point(0, 0);
            this.graphTab.Name = "graphTab";
            this.graphTab.Size = new System.Drawing.Size(0, 0);
            this.graphTab.Text = "Graph";
            // 
            // gridTab
            // 
            this.gridTab.Controls.Add(this.gridTableLayoutPanel);
            this.gridTab.Location = new System.Drawing.Point(1, 25);
            this.gridTab.Name = "gridTab";
            this.gridTab.Size = new System.Drawing.Size(620, 385);
            this.gridTab.Text = "Grid";
            // 
            // gridTableLayoutPanel
            // 
            this.gridTableLayoutPanel.AutoScroll = true;
            this.gridTableLayoutPanel.AutoSize = true;
            this.gridTableLayoutPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridTableLayoutPanel.ColumnCount = 2;

            this.gridTableLayoutPanel.ColumnStyles.Add
                (new ColumnStyle
                    (SizeType.Percent, 50F));

            this.gridTableLayoutPanel.ColumnStyles.Add
                (new ColumnStyle
                    (SizeType.Percent, 50F));

            this.gridTableLayoutPanel.Dock = DockStyle.Fill;

            this.gridTableLayoutPanel.GrowStyle =
                TableLayoutPanelGrowStyle.FixedSize;

            this.gridTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.gridTableLayoutPanel.Name = "gridTableLayoutPanel";
            this.gridTableLayoutPanel.RowCount = 2;

            this.gridTableLayoutPanel.RowStyles.Add(new RowStyle
                (SizeType.Percent, 50F));

            this.gridTableLayoutPanel.RowStyles.Add(new RowStyle
                (SizeType.Percent, 50F));

            this.gridTableLayoutPanel.Size = new System.Drawing.Size(620, 385);
            this.gridTableLayoutPanel.TabIndex = 0;
            this.gridTableLayoutPanel.TabStop = true;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
                {
                    this.helpAboutToolStripMenuItem
                });

            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";

            this.helpToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.H)));

            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);

            this.helpAboutToolStripMenuItem.Click +=
                new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.BorderStyle = BorderStyle.Fixed3D;
            this.tabControl1.ContentAlignment = Manina.Windows.Forms.Alignment.Center;
            this.tabControl1.Controls.Add(this.gridTab);
            this.tabControl1.Controls.Add(this.graphTab);
            this.tabControl1.Cursor = Cursors.Default;
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.MinimumSize = new System.Drawing.Size(622, 411);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 411);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Tabs.Add(this.gridTab);
            this.tabControl1.Tabs.Add(this.graphTab);
            this.tabControl1.TabSize = new System.Drawing.Size(75, 25);
            this.tabControl1.TabSizing = Manina.Windows.Forms.TabSizing.Fixed;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems
                .AddRange(new ToolStripItem[]
                {
                    this.viewToggleDarkModeToolStripMenuItem
                });

            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";

            this.viewToolStripMenuItem.ShortcutKeys = ((Keys)
                ((Keys.Alt | Keys.V)));

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

            this.viewToggleDarkModeToolStripMenuItem.Click +=
                new System.EventHandler(this.viewToggleDarkModeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(622, 433);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.gridTab.ResumeLayout(false);
            this.gridTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="doDispose">true if managed resources should be disposed; 
        /// otherwise, false.</param>
        protected override void Dispose(bool doDispose)
        {
            if (doDispose && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(doDispose);
        }

        #endregion
    }
}