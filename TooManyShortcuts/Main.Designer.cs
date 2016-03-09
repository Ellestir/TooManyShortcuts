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
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.pnlMenu = new System.Windows.Forms.Panel();
        	this.lblHelp = new System.Windows.Forms.Label();
        	this.fbtnSettings = new System.Windows.Forms.Label();
        	this.fbtnOverview = new System.Windows.Forms.Label();
        	this.pnlLoad = new System.Windows.Forms.Panel();
        	this.groupBox1.SuspendLayout();
        	this.pnlMenu.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// imgListMenu
        	// 
        	this.imgListMenu.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
        	this.imgListMenu.ImageSize = new System.Drawing.Size(32, 32);
        	this.imgListMenu.TransparentColor = System.Drawing.Color.Transparent;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.pnlMenu);
        	this.groupBox1.Controls.Add(this.pnlLoad);
        	this.groupBox1.Location = new System.Drawing.Point(12, 28);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(685, 371);
        	this.groupBox1.TabIndex = 6;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "groupBox1";
        	// 
        	// pnlMenu
        	// 
        	this.pnlMenu.BackColor = System.Drawing.Color.White;
        	this.pnlMenu.Controls.Add(this.lblHelp);
        	this.pnlMenu.Controls.Add(this.fbtnSettings);
        	this.pnlMenu.Controls.Add(this.fbtnOverview);
        	this.pnlMenu.Location = new System.Drawing.Point(6, 19);
        	this.pnlMenu.Name = "pnlMenu";
        	this.pnlMenu.Size = new System.Drawing.Size(142, 346);
        	this.pnlMenu.TabIndex = 6;
        	// 
        	// lblHelp
        	// 
        	this.lblHelp.BackColor = System.Drawing.Color.Gray;
        	this.lblHelp.Dock = System.Windows.Forms.DockStyle.Top;
        	this.lblHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.lblHelp.Location = new System.Drawing.Point(0, 144);
        	this.lblHelp.Name = "lblHelp";
        	this.lblHelp.Size = new System.Drawing.Size(142, 72);
        	this.lblHelp.TabIndex = 3;
        	this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// fbtnSettings
        	// 
        	this.fbtnSettings.BackColor = System.Drawing.Color.Gray;
        	this.fbtnSettings.Dock = System.Windows.Forms.DockStyle.Top;
        	this.fbtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.fbtnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.fbtnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.fbtnSettings.Location = new System.Drawing.Point(0, 72);
        	this.fbtnSettings.Name = "fbtnSettings";
        	this.fbtnSettings.Size = new System.Drawing.Size(142, 72);
        	this.fbtnSettings.TabIndex = 2;
        	this.fbtnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// fbtnOverview
        	// 
        	this.fbtnOverview.BackColor = System.Drawing.Color.Gray;
        	this.fbtnOverview.Dock = System.Windows.Forms.DockStyle.Top;
        	this.fbtnOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.fbtnOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.fbtnOverview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.fbtnOverview.Location = new System.Drawing.Point(0, 0);
        	this.fbtnOverview.Name = "fbtnOverview";
        	this.fbtnOverview.Size = new System.Drawing.Size(142, 72);
        	this.fbtnOverview.TabIndex = 1;
        	this.fbtnOverview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// pnlLoad
        	// 
        	this.pnlLoad.Location = new System.Drawing.Point(154, 19);
        	this.pnlLoad.Name = "pnlLoad";
        	this.pnlLoad.Size = new System.Drawing.Size(525, 346);
        	this.pnlLoad.TabIndex = 4;
        	this.pnlLoad.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLoad_Paint);
        	// 
        	// Main
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(709, 439);
        	this.Controls.Add(this.groupBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "Main";
        	this.Text = "Main";
        	this.Load += new System.EventHandler(this.Main_Load);
        	this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainKeyDown);
        	this.groupBox1.ResumeLayout(false);
        	this.pnlMenu.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.GroupBox groupBox1;

        #endregion
        private System.Windows.Forms.ImageList imgListMenu;
        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label fbtnSettings;
        private System.Windows.Forms.Label fbtnOverview;
    }
}