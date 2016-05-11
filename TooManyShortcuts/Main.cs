using System;
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
        XMLShortcutList XMLTempList = new XMLShortcutList();
        ShortCutList sclForm = new ShortCutList();
        public static ListViewItem selecteditem;


        public Main()
        {

            InitializeComponent();
            this.Text = "TooManyShortcuts " + Application.ProductVersion;
            this.MinimizeBox = false;
            NIMain.Icon = Properties.Resources.Keyboard;

        }


        private void Main_Load(object sender, EventArgs e)
        {

            // Damit form in andere Form geladen werden kann / Zukünftige Changes : Usercontrol
            if (Functions.CheckWindowsStartUp() == "firststart" || Functions.CheckWindowsStartUp() == "activated")
            {
                autostartToolStripMenuItem.Checked = true;
            }
            else
            {
                autostartToolStripMenuItem.Checked = false;
            }
            sclForm.TopLevel = false;
            sclForm.FormBorderStyle = FormBorderStyle.None;
            pnlLoad.Controls.Add(sclForm);
            sclForm.Dock = DockStyle.Fill;
            sclForm.Show();
            Application.DoEvents();
        }
        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NIMain.Icon = null;
            this.Dispose();
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
        }


        private void autostartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Functions.SetWindowsStartUp(autostartToolStripMenuItem.Checked);

        }
        

        private void NIMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }
    }
}
