/*
 * Created by SharpDevelop.
 * User: r401-fobi1
 * Date: 01.12.2015
 * Time: 11:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TooManyShortcuts
{
	partial class Edit
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
            this.components = new System.ComponentModel.Container();
            this.grpBoxEdit = new System.Windows.Forms.GroupBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.lblParameter = new System.Windows.Forms.Label();
            this.txtShorthand = new System.Windows.Forms.TextBox();
            this.lblShortHand = new System.Windows.Forms.Label();
            this.lblShortCut = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.EPShortcut = new System.Windows.Forms.ErrorProvider(this.components);
            this.EPShortHand = new System.Windows.Forms.ErrorProvider(this.components);
            this.FixedtxtShortcuts = new FixedTextBox();
            this.grpBoxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPShortcut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPShortHand)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxEdit
            // 
            this.grpBoxEdit.BackColor = System.Drawing.SystemColors.Window;
            this.grpBoxEdit.Controls.Add(this.FixedtxtShortcuts);
            this.grpBoxEdit.Controls.Add(this.btnAbort);
            this.grpBoxEdit.Controls.Add(this.txtParameter);
            this.grpBoxEdit.Controls.Add(this.lblParameter);
            this.grpBoxEdit.Controls.Add(this.txtShorthand);
            this.grpBoxEdit.Controls.Add(this.lblShortHand);
            this.grpBoxEdit.Controls.Add(this.lblShortCut);
            this.grpBoxEdit.Controls.Add(this.txtName);
            this.grpBoxEdit.Controls.Add(this.lblName);
            this.grpBoxEdit.Controls.Add(this.btnSave);
            this.grpBoxEdit.Controls.Add(this.txtPath);
            this.grpBoxEdit.Controls.Add(this.btnPath);
            this.grpBoxEdit.Controls.Add(this.lblPath);
            this.grpBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxEdit.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxEdit.Location = new System.Drawing.Point(0, 0);
            this.grpBoxEdit.Name = "grpBoxEdit";
            this.grpBoxEdit.Size = new System.Drawing.Size(488, 187);
            this.grpBoxEdit.TabIndex = 16;
            this.grpBoxEdit.TabStop = false;
            this.grpBoxEdit.Text = "Hinzufügen oder Ändern eines Shortcuts";
            // 
            // btnAbort
            // 
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(369, 138);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(95, 28);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.BtnAbortClick);
            // 
            // txtParameter
            // 
            this.txtParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParameter.Location = new System.Drawing.Point(90, 86);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(374, 20);
            this.txtParameter.TabIndex = 11;
            // 
            // lblParameter
            // 
            this.lblParameter.AutoSize = true;
            this.lblParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParameter.Location = new System.Drawing.Point(6, 87);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(78, 17);
            this.lblParameter.TabIndex = 10;
            this.lblParameter.Text = "Parameter:";
            // 
            // txtShorthand
            // 
            this.txtShorthand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShorthand.Location = new System.Drawing.Point(310, 112);
            this.txtShorthand.Name = "txtShorthand";
            this.txtShorthand.Size = new System.Drawing.Size(124, 20);
            this.txtShorthand.TabIndex = 9;
            this.txtShorthand.TextChanged += new System.EventHandler(this.TxtShorthandTextChanged);
            this.txtShorthand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtShorthandKeyUp);
            // 
            // lblShortHand
            // 
            this.lblShortHand.AutoSize = true;
            this.lblShortHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortHand.Location = new System.Drawing.Point(226, 113);
            this.lblShortHand.Name = "lblShortHand";
            this.lblShortHand.Size = new System.Drawing.Size(78, 17);
            this.lblShortHand.TabIndex = 8;
            this.lblShortHand.Text = "Shorthand:";
            // 
            // lblShortCut
            // 
            this.lblShortCut.AutoSize = true;
            this.lblShortCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortCut.Location = new System.Drawing.Point(6, 113);
            this.lblShortCut.Name = "lblShortCut";
            this.lblShortCut.Size = new System.Drawing.Size(65, 17);
            this.lblShortCut.TabIndex = 6;
            this.lblShortCut.Text = "Shortcut:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(90, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(374, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(268, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnEditFinishedClick);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(90, 60);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(315, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnPath
            // 
            this.btnPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPath.Location = new System.Drawing.Point(411, 58);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(53, 23);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.BtnPathClick);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(6, 61);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(41, 17);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Pfad:";
            // 
            // EPShortcut
            // 
            this.EPShortcut.ContainerControl = this;
            // 
            // EPShortHand
            // 
            this.EPShortHand.ContainerControl = this;
            // 
            // FixedtxtShortcuts
            // 
            this.FixedtxtShortcuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixedtxtShortcuts.Location = new System.Drawing.Point(90, 112);
            this.FixedtxtShortcuts.Name = "FixedtxtShortcuts";
            this.FixedtxtShortcuts.Size = new System.Drawing.Size(112, 20);
            this.FixedtxtShortcuts.TabIndex = 13;
            this.FixedtxtShortcuts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FixedTextBoxShortCutKeyDown);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(488, 187);
            this.Controls.Add(this.grpBoxEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Edit";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.EditLoad);
            this.grpBoxEdit.ResumeLayout(false);
            this.grpBoxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EPShortcut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EPShortHand)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ErrorProvider EPShortHand;
		private System.Windows.Forms.ErrorProvider EPShortcut;
		private FixedTextBox FixedtxtShortcuts;
		private System.Windows.Forms.Button btnAbort;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnPath;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblShortCut;
		private System.Windows.Forms.Label lblShortHand;
		private System.Windows.Forms.TextBox txtShorthand;
		private System.Windows.Forms.Label lblParameter;
		private System.Windows.Forms.TextBox txtParameter;
		private System.Windows.Forms.GroupBox grpBoxEdit;
    }
}
