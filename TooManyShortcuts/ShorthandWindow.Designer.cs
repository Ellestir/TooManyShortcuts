/*
 * Created by SharpDevelop.
 * User: Anni
 * Date: 19.12.2015
 * Time: 15:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TooManyShortcuts
{
	partial class ShorthandWindow
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtShorthand = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtShorthand
            // 
            this.txtShorthand.Location = new System.Drawing.Point(9, 10);
            this.txtShorthand.Margin = new System.Windows.Forms.Padding(2);
            this.txtShorthand.Name = "txtShorthand";
            this.txtShorthand.Size = new System.Drawing.Size(206, 20);
            this.txtShorthand.TabIndex = 0;
            this.txtShorthand.TextChanged += new System.EventHandler(this.TxtShorthandTextChanged);
            // 
            // ShorthandWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 41);
            this.Controls.Add(this.txtShorthand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShorthandWindow";
            this.Text = "Shorthand";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShorthandWindow_FormClosed);
            this.Load += new System.EventHandler(this.ShorthandWindowLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.TextBox txtShorthand;
	}
}
