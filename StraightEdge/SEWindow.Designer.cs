﻿namespace StraightEdge
{
    partial class SEWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SEWindow));
            this.SEWinMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SEWinStatus = new System.Windows.Forms.StatusStrip();
            this.SESaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SEOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SEToolBar = new System.Windows.Forms.ToolStrip();
            this.newControlButton = new System.Windows.Forms.ToolStripButton();
            this.openControlButton = new System.Windows.Forms.ToolStripButton();
            this.saveControlButton = new System.Windows.Forms.ToolStripButton();
            this.printControlButton = new System.Windows.Forms.ToolStripButton();
            this.controlSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importControlButton = new System.Windows.Forms.ToolStripButton();
            this.exportControlButton = new System.Windows.Forms.ToolStripButton();
            this.controlSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoControlButton = new System.Windows.Forms.ToolStripButton();
            this.redoControlButton = new System.Windows.Forms.ToolStripButton();
            this.controlSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutControlButton = new System.Windows.Forms.ToolStripButton();
            this.copyControlButton = new System.Windows.Forms.ToolStripButton();
            this.pasteControlButton = new System.Windows.Forms.ToolStripButton();
            this.SEControlPanel = new System.Windows.Forms.ToolStrip();
            this.SEWinMenu.SuspendLayout();
            this.SEToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // SEWinMenu
            // 
            this.SEWinMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.SEWinMenu.Location = new System.Drawing.Point(0, 0);
            this.SEWinMenu.Name = "SEWinMenu";
            this.SEWinMenu.Size = new System.Drawing.Size(834, 24);
            this.SEWinMenu.TabIndex = 0;
            this.SEWinMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileMenuItem,
            this.openFileMenuItem,
            this.toolStripSeparator,
            this.saveFileMenuItem,
            this.saveAsFileMenuItem,
            this.toolStripSeparator1,
            this.exitFileMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFileMenuItem.Image")));
            this.newFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newFileMenuItem.Text = "&New";
            this.newFileMenuItem.Click += new System.EventHandler(this.newFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openFileMenuItem.Text = "&Open";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFileMenuItem.Image")));
            this.saveFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveFileMenuItem.Text = "&Save";
            this.saveFileMenuItem.Click += new System.EventHandler(this.saveFileMenuItem_Click);
            // 
            // saveAsFileMenuItem
            // 
            this.saveAsFileMenuItem.Name = "saveAsFileMenuItem";
            this.saveAsFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsFileMenuItem.Text = "Save &As";
            this.saveAsFileMenuItem.Click += new System.EventHandler(this.saveAsFileMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitFileMenuItem
            // 
            this.exitFileMenuItem.Name = "exitFileMenuItem";
            this.exitFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitFileMenuItem.Text = "E&xit";
            this.exitFileMenuItem.Click += new System.EventHandler(this.exitFileMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoEditMenuItem,
            this.redoEditMenuItem,
            this.toolStripSeparator3,
            this.cutEditMenuItem,
            this.copyEditMenuItem,
            this.pasteEditMenuItem,
            this.toolStripSeparator4,
            this.selectAllEditMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoEditMenuItem
            // 
            this.undoEditMenuItem.Name = "undoEditMenuItem";
            this.undoEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoEditMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoEditMenuItem.Text = "&Undo";
            this.undoEditMenuItem.Click += new System.EventHandler(this.undoEditMenuItem_Click);
            // 
            // redoEditMenuItem
            // 
            this.redoEditMenuItem.Name = "redoEditMenuItem";
            this.redoEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoEditMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoEditMenuItem.Text = "&Redo";
            this.redoEditMenuItem.Click += new System.EventHandler(this.redoEditMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutEditMenuItem
            // 
            this.cutEditMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cutEditMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutEditMenuItem.Image")));
            this.cutEditMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutEditMenuItem.Name = "cutEditMenuItem";
            this.cutEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutEditMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutEditMenuItem.Text = "Cu&t";
            this.cutEditMenuItem.Click += new System.EventHandler(this.cutEditMenuItem_Click);
            // 
            // copyEditMenuItem
            // 
            this.copyEditMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyEditMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyEditMenuItem.Image")));
            this.copyEditMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyEditMenuItem.Name = "copyEditMenuItem";
            this.copyEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyEditMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyEditMenuItem.Text = "&Copy";
            this.copyEditMenuItem.Click += new System.EventHandler(this.copyEditMenuItem_Click);
            // 
            // pasteEditMenuItem
            // 
            this.pasteEditMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pasteEditMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteEditMenuItem.Image")));
            this.pasteEditMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteEditMenuItem.Name = "pasteEditMenuItem";
            this.pasteEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteEditMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteEditMenuItem.Text = "&Paste";
            this.pasteEditMenuItem.Click += new System.EventHandler(this.pasteEditMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllEditMenuItem
            // 
            this.selectAllEditMenuItem.Name = "selectAllEditMenuItem";
            this.selectAllEditMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllEditMenuItem.Text = "Select &All";
            this.selectAllEditMenuItem.Click += new System.EventHandler(this.selectAllEditMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutHelpMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutHelpMenuItem
            // 
            this.aboutHelpMenuItem.Name = "aboutHelpMenuItem";
            this.aboutHelpMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutHelpMenuItem.Text = "&About...";
            this.aboutHelpMenuItem.Click += new System.EventHandler(this.aboutHelpMenuItem_Click);
            // 
            // SEWinStatus
            // 
            this.SEWinStatus.Location = new System.Drawing.Point(0, 589);
            this.SEWinStatus.Name = "SEWinStatus";
            this.SEWinStatus.Size = new System.Drawing.Size(834, 22);
            this.SEWinStatus.TabIndex = 1;
            this.SEWinStatus.Text = "statusStrip1";
            // 
            // SESaveFileDialog
            // 
            this.SESaveFileDialog.Title = "Save SE file";
            // 
            // SEOpenFileDialog
            // 
            this.SEOpenFileDialog.Title = "Open SE file";
            // 
            // SEToolBar
            // 
            this.SEToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SEToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newControlButton,
            this.openControlButton,
            this.saveControlButton,
            this.printControlButton,
            this.controlSeparator1,
            this.importControlButton,
            this.exportControlButton,
            this.controlSeparator2,
            this.undoControlButton,
            this.redoControlButton,
            this.controlSeparator3,
            this.cutControlButton,
            this.copyControlButton,
            this.pasteControlButton});
            this.SEToolBar.Location = new System.Drawing.Point(0, 24);
            this.SEToolBar.Name = "SEToolBar";
            this.SEToolBar.Size = new System.Drawing.Size(834, 25);
            this.SEToolBar.TabIndex = 2;
            this.SEToolBar.Text = "toolStrip1";
            // 
            // newControlButton
            // 
            this.newControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newControlButton.Image = ((System.Drawing.Image)(resources.GetObject("newControlButton.Image")));
            this.newControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newControlButton.Name = "newControlButton";
            this.newControlButton.Size = new System.Drawing.Size(23, 22);
            this.newControlButton.Text = "&New";
            // 
            // openControlButton
            // 
            this.openControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openControlButton.Image = ((System.Drawing.Image)(resources.GetObject("openControlButton.Image")));
            this.openControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openControlButton.Name = "openControlButton";
            this.openControlButton.Size = new System.Drawing.Size(23, 22);
            this.openControlButton.Text = "&Open";
            // 
            // saveControlButton
            // 
            this.saveControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveControlButton.Image = ((System.Drawing.Image)(resources.GetObject("saveControlButton.Image")));
            this.saveControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveControlButton.Name = "saveControlButton";
            this.saveControlButton.Size = new System.Drawing.Size(23, 22);
            this.saveControlButton.Text = "&Save";
            // 
            // printControlButton
            // 
            this.printControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printControlButton.Image = ((System.Drawing.Image)(resources.GetObject("printControlButton.Image")));
            this.printControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printControlButton.Name = "printControlButton";
            this.printControlButton.Size = new System.Drawing.Size(23, 22);
            this.printControlButton.Text = "&Print";
            // 
            // controlSeparator1
            // 
            this.controlSeparator1.Name = "controlSeparator1";
            this.controlSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // importControlButton
            // 
            this.importControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importControlButton.Image = global::StraightEdge.Properties.Resources.import;
            this.importControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importControlButton.Name = "importControlButton";
            this.importControlButton.Size = new System.Drawing.Size(23, 22);
            this.importControlButton.Text = "Import";
            // 
            // exportControlButton
            // 
            this.exportControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportControlButton.Image = global::StraightEdge.Properties.Resources.export;
            this.exportControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportControlButton.Name = "exportControlButton";
            this.exportControlButton.Size = new System.Drawing.Size(23, 22);
            this.exportControlButton.Text = "Export";
            // 
            // controlSeparator2
            // 
            this.controlSeparator2.Name = "controlSeparator2";
            this.controlSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // undoControlButton
            // 
            this.undoControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoControlButton.Image = ((System.Drawing.Image)(resources.GetObject("undoControlButton.Image")));
            this.undoControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoControlButton.Name = "undoControlButton";
            this.undoControlButton.Size = new System.Drawing.Size(23, 22);
            this.undoControlButton.Text = "Undo";
            // 
            // redoControlButton
            // 
            this.redoControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoControlButton.Image = ((System.Drawing.Image)(resources.GetObject("redoControlButton.Image")));
            this.redoControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoControlButton.Name = "redoControlButton";
            this.redoControlButton.Size = new System.Drawing.Size(23, 22);
            this.redoControlButton.Text = "Redo";
            // 
            // controlSeparator3
            // 
            this.controlSeparator3.Name = "controlSeparator3";
            this.controlSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cutControlButton
            // 
            this.cutControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutControlButton.Image = ((System.Drawing.Image)(resources.GetObject("cutControlButton.Image")));
            this.cutControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutControlButton.Name = "cutControlButton";
            this.cutControlButton.Size = new System.Drawing.Size(23, 22);
            this.cutControlButton.Text = "C&ut";
            // 
            // copyControlButton
            // 
            this.copyControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyControlButton.Image = ((System.Drawing.Image)(resources.GetObject("copyControlButton.Image")));
            this.copyControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyControlButton.Name = "copyControlButton";
            this.copyControlButton.Size = new System.Drawing.Size(23, 22);
            this.copyControlButton.Text = "&Copy";
            // 
            // pasteControlButton
            // 
            this.pasteControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteControlButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteControlButton.Image")));
            this.pasteControlButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteControlButton.Name = "pasteControlButton";
            this.pasteControlButton.Size = new System.Drawing.Size(23, 22);
            this.pasteControlButton.Text = "&Paste";
            // 
            // SEControlPanel
            // 
            this.SEControlPanel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SEControlPanel.Location = new System.Drawing.Point(0, 49);
            this.SEControlPanel.Name = "SEControlPanel";
            this.SEControlPanel.Size = new System.Drawing.Size(834, 25);
            this.SEControlPanel.TabIndex = 3;
            this.SEControlPanel.Text = "SEToolBar";
            // 
            // SEWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 611);
            this.Controls.Add(this.SEControlPanel);
            this.Controls.Add(this.SEToolBar);
            this.Controls.Add(this.SEWinStatus);
            this.Controls.Add(this.SEWinMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.SEWinMenu;
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "SEWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StraightEdge";
            this.SEWinMenu.ResumeLayout(false);
            this.SEWinMenu.PerformLayout();
            this.SEToolBar.ResumeLayout(false);
            this.SEToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip SEWinMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoEditMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteEditMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHelpMenuItem;
        private System.Windows.Forms.StatusStrip SEWinStatus;
        private System.Windows.Forms.SaveFileDialog SESaveFileDialog;
        private System.Windows.Forms.OpenFileDialog SEOpenFileDialog;
        private System.Windows.Forms.ToolStrip SEToolBar;
        private System.Windows.Forms.ToolStripButton newControlButton;
        private System.Windows.Forms.ToolStripButton openControlButton;
        private System.Windows.Forms.ToolStripButton saveControlButton;
        private System.Windows.Forms.ToolStripButton printControlButton;
        private System.Windows.Forms.ToolStripSeparator controlSeparator1;
        private System.Windows.Forms.ToolStripButton cutControlButton;
        private System.Windows.Forms.ToolStripButton copyControlButton;
        private System.Windows.Forms.ToolStripButton pasteControlButton;
        private System.Windows.Forms.ToolStripButton importControlButton;
        private System.Windows.Forms.ToolStripButton exportControlButton;
        private System.Windows.Forms.ToolStripSeparator controlSeparator2;
        private System.Windows.Forms.ToolStripButton undoControlButton;
        private System.Windows.Forms.ToolStripButton redoControlButton;
        private System.Windows.Forms.ToolStripSeparator controlSeparator3;
        private System.Windows.Forms.ToolStrip SEControlPanel;        
    }
}

