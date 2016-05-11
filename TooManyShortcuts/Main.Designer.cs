namespace TooManyShortcuts
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.imgListMenu = new System.Windows.Forms.ImageList(this.components);
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.conMenStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autostartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NIMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.conMenStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListMenu
            // 
            this.imgListMenu.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListMenu.ImageSize = new System.Drawing.Size(32, 32);
            this.imgListMenu.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlLoad
            // 
            this.pnlLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoad.Location = new System.Drawing.Point(0, 0);
            this.pnlLoad.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(536, 439);
            this.pnlLoad.TabIndex = 5;
            // 
            // conMenStrip
            // 
            this.conMenStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autostartToolStripMenuItem,
            this.toolStripMenuItem1});
            this.conMenStrip.Name = "conMenStrip";
            this.conMenStrip.Size = new System.Drawing.Size(124, 48);
            // 
            // autostartToolStripMenuItem
            // 
            this.autostartToolStripMenuItem.CheckOnClick = true;
            this.autostartToolStripMenuItem.Name = "autostartToolStripMenuItem";
            this.autostartToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.autostartToolStripMenuItem.Text = "Autostart";
            this.autostartToolStripMenuItem.Click += new System.EventHandler(this.autostartToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem1.Text = "Beenden";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // NIMain
            // 
            this.NIMain.ContextMenuStrip = this.conMenStrip;
            this.NIMain.Text = "TooManyShortcuts";
            this.NIMain.Visible = true;
            this.NIMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NIMain_MouseDoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 439);
            this.Controls.Add(this.pnlLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.conMenStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgListMenu;
        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.ContextMenuStrip conMenStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem autostartToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon NIMain;
    }
}