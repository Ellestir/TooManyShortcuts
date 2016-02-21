﻿/*
 * Created by SharpDevelop.
 * User: r401-fobi1
 * Date: 01.12.2015
 * Time: 11:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using System.Diagnostics;
using System.Collections.Generic;
namespace TooManyShortcuts
{
    /// <summary>
    /// Description of Edit.
    /// </summary>
    public partial class Edit : Form
    {

        KeyMods KeyMod = new KeyMods(); 
        ListView lv = new ListView();
       public  int formwidth = 0;

        public Edit()

        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //

            InitializeComponent(); 

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

        }

        /// <summary>
        /// Kontruktor mit Paramtern für die einzelnen Felder. 
        /// </summary>
        /// <param name="Name">Name</param>
        /// <param name="Path">Pfad</param>
        /// <param name="Parameter">Parameter z.B. /call in Skype</param>
        /// <param name="Shortcut">z.B dieses Format: STRG + D </param>
        /// <param name="Shorthand">Max drei Zeichen z.B. AAA</param>
        public Edit(string Name, string Path, string Parameter, string Shortcut, string Shorthand)
        {
            InitializeComponent();
            txtName.Text = Name;
            txtPath.Text = Path;
            txtParameter.Text = Parameter;
            FixedtxtShortcuts.Text = Shortcut;
            txtShorthand.Text = Shorthand;
          
           
        }

        /// <summary>
        /// Objektübergabe von der MainKlasse an die EditKlasse (Dient zur Verarbeitung und auslesen der Liste.) 
        /// </summary>
        public void TakeMyObjects(ListView lv)
        {
            this.lv = lv; // Liste wird gespeichert

        }

        /// <summary>
        /// Läd das Selektierte Objekt in die Editierungsform
        /// </summary> 
        public void LoadList()
        {
     
            txtName.Text = lv.SelectedItems[0].SubItems[0].Text;
            txtPath.Text = lv.SelectedItems[0].SubItems[1].Text;
            txtParameter.Text = lv.SelectedItems[0].SubItems[2].Text;
            FixedtxtShortcuts.Text = lv.SelectedItems[0].SubItems[3].Text;
            txtShorthand.Text = lv.SelectedItems[0].SubItems[4].Text;
        }




        /// <summary>
        /// Öffnet einen OpenfileDialog der es ermöglicht exe Datei sowie alle Dateien als Pfad auszuwählen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnPathClick(object sender, EventArgs e)
        {
            
            OpenFileDialog odf = new OpenFileDialog(); //Erstellt ein OpenfileDialog in dem Sich Dateien etc auswählen lassen 
            if (txtPath.Text == "") { odf.InitialDirectory = "C:\\Program Files"; } // Wenn die Textbox leer war wird C:\\Program Files als Einstiegsordner gewählt.
            else { odf.InitialDirectory = txtPath.Text.Substring(0, txtPath.Text.LastIndexOf('\\')); }; // Springt auf den Ordner zurück wenn eine Datei gegeben war
            odf.Filter = "Excetuable File (*.exe)|*.exe|All files (*.*)|*.*";

            if ((odf.ShowDialog() == DialogResult.OK))
            {
                txtPath.Text = odf.FileName;

                txtParameter.Focus();

            }

        }






        void EditLoad(object sender, EventArgs e)
        {
            // Legt lediglich die TabIndex Reinfolge der Elemente fest
            // Somit ist einfaches durchtappen mit der Taptaste gegeben
            formwidth = this.Width;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.grpBoxEdit.BackColor = System.Drawing.SystemColors.Window;
            txtName.TabIndex = 0;
            txtPath.TabIndex = 1;
            btnPath.TabIndex = 2;
            txtParameter.TabIndex = 3;
            FixedtxtShortcuts.TabIndex = 4;
            txtShorthand.TabIndex = 5;
            btnSave.TabIndex = 6;
            btnAbort.TabIndex = 7;

            // Wird benötigt um Drag an Drop in der Textbox durchzuführen 
            txtPath.AllowDrop = true;
            txtPath.DragEnter += new DragEventHandler(txtPath_DragEnter);
            txtPath.DragDrop += new DragEventHandler(txtPath_DragDrop);


            FixedtxtShortcuts.Multiline = false; // Textbox bleibt in angemessener Größe
            FixedtxtShortcuts.ReadOnly = true; // Textbox kann nur gelesen werden 



        }



        void BtnAbortClick(object sender, EventArgs e)
        {

            //Schließt die Edit Form in der Hauptform und setzt die Liste wieder auf eine große Ansicht 
            this.Hide(); 

            // #INPROCESS
        }

       
        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            Functions.FileDragEnter(e);
        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            Functions.FileDragDrop(e);
            txtName.Text = Functions.DDFileName;
            txtPath.Text = Functions.DDPath;

        }


        /// <summary>
        /// Wenn ein Tastendruck auf der FixedTextBox ausgeführt wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FixedTextBoxShortCutKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape ) { FixedtxtShortcuts.Text = null; }
            if (e.Modifiers == Keys.Control && e.KeyCode != Keys.ControlKey)
            {
                FixedtxtShortcuts.Text = "STRG + " + e.KeyCode.ToString();
                KeyMod = KeyMods.Control;

            }
            else if (e.Modifiers == Keys.Alt && e.KeyCode != Keys.Menu)
            {
                FixedtxtShortcuts.Text = "ALT + " + e.KeyCode.ToString();
                KeyMod= KeyMods.Alt;

            }
            else if (e.Modifiers == Keys.Shift && e.KeyCode != Keys.ShiftKey)
            {
                FixedtxtShortcuts.Text = "SHIFT + " + e.KeyCode.ToString();
                KeyMod = KeyMods.Shift;

            }


        }





        void BtnEditFinishedClick(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPath.Text != "" &&  txtShorthand.Text.Length <= 3 &&  (FixedtxtShortcuts.Text != "" || txtShorthand.Text != "" )   )
            {
                try
                {
                    Functions.RegisterHotKey(FixedtxtShortcuts.Text);
                }
                catch (Exception q )
                {
                    MessageBox.Show(q.Message);
                    throw;
                }
               
                // WEITERMAXHEN  (ÜBERPRÜFUNG  NACH SHORTHANDS ETC.) 
            }



        }



        void TxtShorthandTextChanged(object sender, EventArgs e)
        {

            txtShorthand.Text = txtShorthand.Text.ToUpper();
            txtShorthand.Select(txtShorthand.Text.Length, 0);
        }

        private void lblParamHelp_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "") { Process.Start("https://www.google.de/search?q=" + txtName.Text + "+command+line+parameters"); }
            else { MessageBox.Show(""); }//#INPROCESS
        }
    }
}



