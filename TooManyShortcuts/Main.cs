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
        int _loadedpanel = 0;
        Edit edtform = new Edit();
        ShortCutList sclForm = new ShortCutList();
        public static ListViewItem selecteditem;
        string MenuIconPath = Application.StartupPath + "\\Icons\\Menu";


        public Main()
        {

            
            InitializeComponent();
            lblOverview.Click +=  new System.EventHandler(ColorMenuControls);
            lblSettings.Click += new System.EventHandler(ColorMenuControls);
            lblHelp.Click += new System.EventHandler(ColorMenuControls);

            

            lblOverview.MouseMove += new System.Windows.Forms.MouseEventHandler(JustMakeItGray);
            lblSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(JustMakeItGray);
            lblHelp.MouseMove += new System.Windows.Forms.MouseEventHandler(JustMakeItGray);


            lblOverview.MouseLeave += new System.EventHandler(MakeItNormalAgain);
            lblSettings.MouseLeave += new System.EventHandler(MakeItNormalAgain);
            lblHelp.MouseLeave += new System.EventHandler(MakeItNormalAgain);
        }
      



        private void Main_Load(object sender, EventArgs e)
        {
            TestTheme();
          
            string[] startparameters = Environment.GetCommandLineArgs();
            
            Functions.RegisterHotKey("STRG + Space");
            DoTheButtons(); 
          
            fbtnOverview_Click(sender, e);

            // this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.Fixed3D;
           

        }

        private void DoTheButtons()
        {
            Functions.FillImageList(MenuIconPath,imgListMenu, "*.png");




            lblOverview.ImageList = imgListMenu; // Definition ImgList
            lblOverview.ImageAlign = ContentAlignment.MiddleLeft;
            lblOverview.ImageKey = "Home";
            lblOverview.TextAlign = ContentAlignment.MiddleCenter;
            lblOverview.Text = "Home";
           
            lblSettings.Text = "          Create/ Edit Shortcuts";
            //fbtnEdit.ImageList = imgListMenu;
            //fbtnEdit.ImageKey = "Tools";
        }


        /// <summary>
        /// TestMethode ThemeChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TestTheme()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.BackgroundImage = Image.FromFile("C:\\temp\\Test.jpg"); 
            // Schelcht programmiert
            pnlLoad.BackColor = this.BackColor = Color.FromArgb(59, 60, 62);
        }



        private void fbtnOverview_Click(object sender, EventArgs e)
        {
            CleanPanel(1,sclForm);
        }




        //  Reinigt das pnlLoad jedoch nur wenn ein anderer Button gedrückt wurde ( Andere Form wird dann geladen) 


        private void fbtnSettings_Click(object sender, EventArgs e)
        {
            CleanPanel(2, edtform); 
            
        }







        public  void CleanPanel(int loadedpanel,Form f)
        {
           
            if (_loadedpanel != loadedpanel)
            {
                foreach (Control c in pnlLoad.Controls) { c.Hide(); }
                _loadedpanel = loadedpanel;

                f.TopLevel = false;

                f.FormBorderStyle = FormBorderStyle.None;

                pnlLoad.Controls.Add(f);

                f.Dock = DockStyle.Fill;
                f.Show();
                Application.DoEvents();
                if (_loadedpanel == 1) { this.Width = sclForm.sclFormWidth + pnlMenu.Width; }
                if (_loadedpanel == 2) { this.Width = edtform.formwidth + pnlMenu.Width; }

                

            }

        }

     
        private void ColorMenuControls(object sender, EventArgs e)
        {
            foreach (Control ctr in pnlMenu.Controls)
            {
                if (ctr is Label) { ctr.BackColor = Color.Gray; }
            }
            Label lbl = (Label)sender; 
            lbl.BackColor = Color.DimGray;
           
        }
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

        private void pnlLoad_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;


            //g.DrawRoundedRectangle(new Pen(Color.Black), 12, 12, this.Width - 44, this.Height - 64, 10);
        }

     


    }
}
