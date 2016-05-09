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
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(421, 439);
            this.pnlLoad.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 439);
            this.Controls.Add(this.pnlLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgListMenu;
        private System.Windows.Forms.Panel pnlLoad;
    }
}