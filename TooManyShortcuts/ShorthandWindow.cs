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
        
        public ShorthandWindow()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ShorthandWindowLoad(object sender, EventArgs e)
		{
            BringToFront();
            this.ShowIcon = false;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width	/ 2 - this.Width / 2,Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2); 
			this.TopMost = true;
            txtShorthand.CharacterCasing = CharacterCasing.Upper;
            txtShorthand.Focus();
		    
		}
		

		
		void TxtShorthandTextChanged(object sender, EventArgs e)
		{
            if(txtShorthand.Text != "")
            {
                int hitcounter = 0;
                DataRow hit = null;
                txtShorthand.Select(txtShorthand.Text.Length, 0);

                foreach (DataRow row in ShortCutList.ShortCutTable.Rows)
                {

                    if (row["Shorthand"].ToString().StartsWith(txtShorthand.Text))
                    {
                        hitcounter += 1;
                        hit = row;
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
    }
}
