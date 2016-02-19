namespace TooManyShortcuts
{
    partial class ShortCutList
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cBoxSearchType = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmParameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmShortcut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmShorthand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvShortcuts = new System.Windows.Forms.ListView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize = new System.Drawing.Size(50, 50);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cBoxSearchType
            // 
            this.cBoxSearchType.FormattingEnabled = true;
            this.cBoxSearchType.Location = new System.Drawing.Point(340, 14);
            this.cBoxSearchType.Name = "cBoxSearchType";
            this.cBoxSearchType.Size = new System.Drawing.Size(121, 21);
            this.cBoxSearchType.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Andalus", 12F);
            this.lblSearch.Location = new System.Drawing.Point(12, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 26);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Suchen: ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Andalus", 12F);
            this.lblType.Location = new System.Drawing.Point(298, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 26);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Art:";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.lblSearchIcon);
            this.pnlSearch.Controls.Add(this.btnNew);
            this.pnlSearch.Controls.Add(this.lblType);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.cBoxSearchType);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(602, 44);
            this.pnlSearch.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(468, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New Shortcut";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // clmName
            // 
            this.clmName.Tag = "1";
            this.clmName.Text = "Name";
            this.clmName.Width = 57;
            // 
            // clmPath
            // 
            this.clmPath.Tag = "1";
            this.clmPath.Text = "Pfad";
            this.clmPath.Width = 146;
            // 
            // clmParameter
            // 
            this.clmParameter.Tag = "1";
            this.clmParameter.Text = "Parameter";
            this.clmParameter.Width = 143;
            // 
            // clmShortcut
            // 
            this.clmShortcut.Tag = "1";
            this.clmShortcut.Text = "Shortcut";
            this.clmShortcut.Width = 81;
            // 
            // clmShorthand
            // 
            this.clmShorthand.Tag = "1";
            this.clmShorthand.Text = "Shorthand";
            this.clmShorthand.Width = 107;
            // 
            // lvShortcuts
            // 
            this.lvShortcuts.BackColor = System.Drawing.SystemColors.Window;
            this.lvShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmPath,
            this.clmParameter,
            this.clmShortcut,
            this.clmShorthand});
            this.lvShortcuts.FullRowSelect = true;
            this.lvShortcuts.GridLines = true;
            this.lvShortcuts.LargeImageList = this.imgList;
            this.lvShortcuts.Location = new System.Drawing.Point(0, 44);
            this.lvShortcuts.Name = "lvShortcuts";
            this.lvShortcuts.Size = new System.Drawing.Size(535, 656);
            this.lvShortcuts.TabIndex = 2;
            this.lvShortcuts.UseCompatibleStateImageBehavior = false;
            this.lvShortcuts.View = System.Windows.Forms.View.Details;
            this.lvShortcuts.DoubleClick += new System.EventHandler(this.lvShortcuts_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.ImageList = this.imgList;
            this.lblSearchIcon.Location = new System.Drawing.Point(257, 17);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(0, 13);
            this.lblSearchIcon.TabIndex = 5;
            // 
            // ShortCutList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 700);
            this.Controls.Add(this.lvShortcuts);
            this.Controls.Add(this.pnlSearch);
            this.Name = "ShortCutList";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ComboBox cBoxSearchType;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmPath;
        private System.Windows.Forms.ColumnHeader clmParameter;
        private System.Windows.Forms.ColumnHeader clmShortcut;
        private System.Windows.Forms.ColumnHeader clmShorthand;
        private System.Windows.Forms.ListView lvShortcuts;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

