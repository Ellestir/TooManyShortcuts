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
      
        Edit edtform = new Edit();
        ShortCutList sclForm = new ShortCutList();
        public static ListViewItem selecteditem;
        string MenuIconPath = Application.StartupPath + "\\Icons\\Menu";


        public Main()
        {

            
            InitializeComponent();
            this.Text = "TooManyShortcuts " + Application.ProductVersion;
           // this.WindowState = FormWindowState.Minimized; 
          
           

        }

    


        private void Main_Load(object sender, EventArgs e)
        {
        	

            sclForm.TopLevel = false;
            sclForm.FormBorderStyle = FormBorderStyle.None;

            pnlLoad.Controls.Add(sclForm); 


            sclForm.Dock = DockStyle.Fill;
            sclForm.Show();
            Application.DoEvents();


            //Functions.StartAtWindowsStartUp(true); //Verändern auf Objekte!



            string[] startparameters = Environment.GetCommandLineArgs();
            
            
          
            
           

        }

    

   
     

      




        //  Reinigt das pnlLoad jedoch nur wenn ein anderer Button gedrückt wurde ( Andere Form wird dann geladen) 


 







     

     
    
        private void JustMakeItGray(object sender, EventArgs e)
        {
            Label snd = (Label)sender;
            if (snd.BackColor != Color.DimGray) { snd.BackColor = Color.DarkGray; }
        }
        private void MakeItNormalAgain(object sender, EventArgs e)
        {
            Label snd = (Label)sender;
            if (snd.BackColor != Color.DimGray) { snd.BackColor = Color.Gray; }
        }

      

        private void NIMain_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal; 
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close(); 
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
            NIMain.Icon = null;
        }
    }
}
