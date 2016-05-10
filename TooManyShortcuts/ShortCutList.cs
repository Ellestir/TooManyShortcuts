using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;





namespace TooManyShortcuts
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ShortCutList : Form
    {
        XMLShortcutList XMLList = new XMLShortcutList();

        //public static DataTable ShortCutTable = new DataTable();



        public int sclFormWidth = 0;
        public static string XMLPath = Application.StartupPath + "\\Config.xml";
        string ProgramIconPath = Application.StartupPath + "\\Icons\\Programs";


        public ShortCutList()
        {
            InitializeComponent();
            // register the event that is fired after the key press.
            this.lvShortcuts.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lvShortcuts_ColumnWidthChanging);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Main_Load(object sender, EventArgs e)
        {
            Functions.IntalizeKeyPressEvent(XMLList);
            Functions.RegisterHotKey("STRG + Space");


            //Icons


            lvShortcuts.AllowDrop = true;
            lvShortcuts.DragEnter += new DragEventHandler(lvShortcuts_DragEnter);
            lvShortcuts.DragDrop += new DragEventHandler(lvShortcuts_DragDrop);
            imgList.ImageSize = new System.Drawing.Size(40, 40);


            Functions.FillImageList(ProgramIconPath, imgList, "*.png");
            lvShortcuts.FullRowSelect = true;
            lvShortcuts.LargeImageList = imgList;
            lvShortcuts.SmallImageList = imgList;
            lvShortcuts.GridLines = true;
            lvShortcuts.MultiSelect = false;


            // Hier Sprache festlegen 
            
            UpdateShortcuts();

            //32 Item Größe
            txtSearch.Focus();
           


            }

        /// <summary>
        /// Läd die Shortcuts aus der XML Datei und schreibt diese in ein Datatable. 
        /// Weiterhin wird die ListView mit den Daten aus der Datatable befühlt.
        /// </summary>
        public void UpdateShortcuts([Optional] Edit edt)
        {
            
            if (edt != null)
            {
                if (edt.ShowDialog(this) == DialogResult.OK)
                {
                    XMLList = edt.XMLListTemp;
                }
            }
          
            lvShortcuts.Items.Clear();

            try
            {
                ListSerializer.DeSerialize(XMLList, XMLPath);
                foreach (Shortcut sc in XMLList.Shortcuts)
                {
                    Functions.RegisterHotKey(sc.Keycombo);
                    ListViewItem item = new ListViewItem();

                    item.Text = sc.Name;
                    item.SubItems.Add(sc.Path);
                    item.SubItems.Add(sc.Parameters);
                    item.SubItems.Add(sc.Keycombo);
                    item.SubItems.Add(sc.Shorthand);
                    SpecialIcons(sc, item); // EasterEgg

                    if (sc.Path.StartsWith("http") == false)
                    {
                        if (System.IO.File.Exists(sc.Path) == false)
                        {
                            item.ForeColor = Color.Red;
                            item.SubItems[1].Text += " (nicht gefunden)";
                        }
                    }


                    lvShortcuts.Items.Add(item); //Add this row to the ListView

                }


            }
            catch
            {
                MessageBox.Show("Dumm gelaufen!");
            }




            if (lvShortcuts.Items.Count == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    lvShortcuts.Columns[i].Width = lvShortcuts.Width / 5;
                }
            }
            else
            {
                lvShortcuts.Columns[1].Width = -2;
                lvShortcuts.Columns[2].Width = -2;
                lvShortcuts.Columns[3].Width = -2;
                lvShortcuts.Columns[4].Width = -2; // -2 Heißt Achte auf ColumnHeader und Content 
                lvShortcuts.Columns[0].Width = -2;
                if (lvShortcuts.Columns[0].Width > 100) { lvShortcuts.Columns[0].Width = 100; } // PFAD zu Lange Streckt das Programm sonst zu krass
                if (lvShortcuts.Columns[1].Width > 100) { lvShortcuts.Columns[1].Width = 100; } // Ekliger Parameter Incoming #Bla 
            }




        }
        /// <summary>
        /// Fügt EasterEggs ABER auch sinnvolle Icons zu Speziellen Zeilen hinzu :3
        /// </summary>
        /// <param name="row">Die Zeilen des DataTalbs</param>
        /// <param name="item">Das ListviewItem</param>
        private void SpecialIcons(Shortcut sc, ListViewItem item)
        {

            // Wenn das Objekt Existiert egal ob es eine Datei oder ein Ordner ist
            if (System.IO.File.Exists(sc.Path) || System.IO.Directory.Exists(sc.Path))
            {

                // Wenn das Objekt eine Datei ist 
                if (System.IO.File.Exists(sc.Path))
                {
                    imgList.Images.Add(sc.Name, Functions.getIcon(sc.Path));
                    item.ImageKey = sc.Name;

                    if (sc.Path.EndsWith(".mp4")) { item.ImageKey = "Video"; } //4 Weil immer ein Element hier hinzugefügt obwohl 5 Datei im Ordner
                    if (sc.Path.EndsWith(".mp3")) { item.ImageKey = "Music"; }

                }

                // Wenn das Objekt ein Ordner ist 
                if (System.IO.Directory.Exists(sc.Path))
                {
                    item.ImageKey = "Folder.png";  // + Wie viele Festdefinierte Bilder 
                                                   // INDEX UMÄNDERN MIT NAME AM BESTEN  rfhwe8ufh 


                }
            }
            else { item.ImageIndex = 2; };


            //Webseiten NOCH BEARBWITEN
            if (sc.Path.Contains("http://")) { item.ImageKey = "Web"; }









            //Porn Icon //MUSS ZULETZT STEHEN DA EASTEREGG
            //if (sc.Name.Contains("Porn")) { item.ImageKey = "Porn"; }
            // if (sc.Path.Contains("porn")) { item.ImageKey = "Porn"; }
            //
        }




        /// <summary>
        /// Befüllt die Checkbox mit den ensprechenden Werten und liegt ihre Autovervollständigung fest. 
        /// </summary>







        /// <summary>
        /// Verhindert das die Columns gezogen oder verkleinert werden 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lvShortcuts_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {

            e.NewWidth = this.lvShortcuts.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
        // Überprufen
       



    








    private void lvShortcuts_DoubleClick(object sender, EventArgs e)
    {
        ListView lv = (ListView)sender;

        Edit edt = new Edit(lv.SelectedItems[0].Text, lv.SelectedItems[0].SubItems[1].Text, lv.SelectedItems[0].SubItems[2].Text, lv.SelectedItems[0].SubItems[3].Text, lv.SelectedItems[0].SubItems[4].Text, XMLList);
        UpdateShortcuts(edt);
        }



    private void lvShortcuts_DragEnter(object sender, DragEventArgs e)
    {
        Functions.FileDragEnter(e);
    }


    /// <summary>
    /// DragDrop Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lvShortcuts_DragDrop(object sender, DragEventArgs e)
    {
        Functions.FileDragDrop(e);
        Edit edt = new Edit(Functions.DDFileName, Functions.DDPath, "", "", "", XMLList);
        UpdateShortcuts(edt);
    }

    private void btnNew_Click(object sender, EventArgs e)
    {


        Edit edt = new Edit(Functions.DDFileName, Functions.DDPath, "", "", "", XMLList);

        UpdateShortcuts(edt);


    }

     

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            lvShortcuts.Items.Clear();

            foreach (Shortcut sc in XMLList.Shortcuts)
            {
                ListViewItem item = new ListViewItem();
                if (sc.Name.Contains(txtSearch.Text) || sc.Path.Contains(txtSearch.Text) || sc.Shorthand.Contains(txtSearch.Text))
                {
                    item.Text = sc.Name;
                    item.SubItems.Add(sc.Path);
                    item.SubItems.Add(sc.Parameters);
                    item.SubItems.Add(sc.Keycombo);
                    item.SubItems.Add(sc.Shorthand);
                    SpecialIcons(sc, item); // EasterEgg
                    if (sc.Path.StartsWith("http") == false)
                    {
                        if (System.IO.File.Exists(sc.Path) == false)
                        {
                            item.ForeColor = Color.Red;
                            item.SubItems[1].Text += " (nicht gefunden)";

                        }
                    }
                    lvShortcuts.Items.Add(item); //Add this row to the ListView
                    
                }


            }
        }
    }


    }









