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
            this.lblSettings = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
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
            this.pnlMenu.Controls.Add(this.lblSettings);
            this.pnlMenu.Controls.Add(this.lblOverview);
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
            // lblSettings
            // 
            this.lblSettings.BackColor = System.Drawing.Color.Gray;
            this.lblSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSettings.Location = new System.Drawing.Point(0, 72);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(142, 72);
            this.lblSettings.TabIndex = 2;
            this.lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverview
            // 
            this.lblOverview.BackColor = System.Drawing.Color.Gray;
            this.lblOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOverview.Location = new System.Drawing.Point(0, 0);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(142, 72);
            this.lblOverview.TabIndex = 1;
            this.lblOverview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox1.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgListMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblOverview;
    }
}