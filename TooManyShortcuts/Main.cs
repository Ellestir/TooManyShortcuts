﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace TooManyShortcuts
{
    public partial class Main : Form
    {
        // Inition 

        Edit edtform = new Edit();
        ShortCutList sclForm = new ShortCutList();
        public static ListViewItem selecteditem;
        string MenuIconPath = Application.StartupPath + "\\Icons\\Menu";


        public Main()
        {


            InitializeComponent();
            this.Text = "TooManyShortcuts " + Application.ProductVersion;
            this.MinimizeBox = false;
           


            
        }




        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            // Damit form in andere Form geladen werden kann / Zukünftige Changes : Usercontrol

            sclForm.TopLevel = false;
            sclForm.FormBorderStyle = FormBorderStyle.None;

            pnlLoad.Controls.Add(sclForm);


            sclForm.Dock = DockStyle.Fill;
            sclForm.Show();
            Application.DoEvents();











        }











        //  Reinigt das pnlLoad jedoch nur wenn ein anderer Button gedrückt wurde ( Andere Form wird dann geladen) 


















        private void NIMain_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NIMain.Icon = null;
            this.Dispose();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {

                this.ShowInTaskbar = false;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;


        }
    }
}
