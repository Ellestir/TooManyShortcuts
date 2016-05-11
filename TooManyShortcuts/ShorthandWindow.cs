/*
 * Created by SharpDevelop.
 * User: Anni
 * Date: 19.12.2015
 * Time: 15:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms; 
namespace TooManyShortcuts
{
	/// <summary>
	/// Description of ShorthandWindow.
	/// </summary>
	public partial class ShorthandWindow : Form
	{

        XMLShortcutList XMLListTemp; 
        public ShorthandWindow(XMLShortcutList XMLListTemp)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            this.XMLListTemp = XMLListTemp;
        }
		
		void ShorthandWindowLoad(object sender, EventArgs e)
		{
            txtShorthand.CharacterCasing = CharacterCasing.Upper;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2);

            

        }
		

		
		void TxtShorthandTextChanged(object sender, EventArgs e)
		{
            if(txtShorthand.Text != "")
            {
                int hitcounter = 0;
                Shortcut hit = null;
                txtShorthand.Select(txtShorthand.Text.Length, 0);

                foreach (Shortcut sc in XMLListTemp.Shortcuts)
                {

                    if (sc.Shorthand.StartsWith(txtShorthand.Text))
                    {
                        hitcounter += 1;
                        hit = sc;
                    }
                }

                if (hitcounter == 1)
                {
                    Functions.StartProcess(hit);
                    this.Close();

                }
            }
            

          

        }

        private void ShorthandWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Functions.forminwork = false;
        }

        private void ShorthandWindow_Activated(object sender, EventArgs e)
        {
        
            this.ShowInTaskbar = true;
            this.BringToFront();
            this.TopLevel = true;
            this.TopMost = true;
            this.Focus();
            txtShorthand.Select();

        }
    }
}
