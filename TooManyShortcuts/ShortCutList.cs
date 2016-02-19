using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;





namespace TooManyShortcuts
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ShortCutList : Form
    {
        public static DataTable ShortCutTable = new DataTable();

        public static string[,] ShortcutList = new string[6, 5]; // StringListe der Shortcuts 
        ImportIcon ico = new ImportIcon(); // Verknüopfung zu Toms KLasse zum Auslesen der Icons
        public int sclFormWidth = 0;
        string XMLPath = Application.StartupPath + "\\Config.xml";
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
            // Themeänderungen
            txtSearch.BackColor = Color.FromArgb(30, 30, 31);
            pnlSearch.BackColor = Color.FromArgb(59, 60, 62);
            lblSearch.ForeColor = Color.White;
            lvShortcuts.BackColor = Color.Gray;



            //Icons
      

            lvShortcuts.AllowDrop = true;
            lvShortcuts.DragEnter += new DragEventHandler(lvShortcuts_DragEnter);
            lvShortcuts.DragDrop += new DragEventHandler(lvShortcuts_DragDrop);
            imgList.ImageSize = new System.Drawing.Size(40, 40);


            Functions.FillImageList(ProgramIconPath,imgList,".png");
            lvShortcuts.FullRowSelect = true;
            lvShortcuts.LargeImageList = imgList;
            lvShortcuts.SmallImageList = imgList;
            lvShortcuts.GridLines = true;
            lvShortcuts.MultiSelect = false;


            // Hier Sprache festlegen 

            LOADXML();
            LoadSearch();

            //32 Item Größe xD 
            txtSearch.Focus();



        }

        /// <summary>
        /// Läd die Shortcuts aus der XML Datei und schreibt diese in ein Datatable. 
        /// Weiterhin wird die ListView mit den Daten aus der Datatable befühlt.
        /// </summary>
        public void LOADXML()
        {


            //Auslesen aus XML
            this.Text = "TooManyShortcuts v0.0.1"; //XML Abfrage einfügen
                                                   //Beispiel Eintrag Anfang

            ShortCutTable.Columns.Add("Name", typeof(string));
            ShortCutTable.Columns.Add("Path", typeof(string));
            ShortCutTable.Columns.Add("Parameter", typeof(string));
            ShortCutTable.Columns.Add("Shortcut", typeof(string));
            ShortCutTable.Columns.Add("Shorthand", typeof(string));

            //TEST

            if (System.IO.File.Exists(XMLPath) == false) { System.IO.File.WriteAllText(XMLPath, ""); }
            String[] a = System.IO.File.ReadAllLines(XMLPath);
            for (int y = 0; y < a.Length; y = y + 5)
            {
                ShortCutTable.Rows.Add(a[y], a[y + 1], a[y + 2], a[y + 3], a[y + 4]);
            }

            foreach (DataRow row in ShortCutTable.Rows)
            {
                Functions.RegisterHotKey(row["Shortcut"].ToString());




                ListViewItem item = new ListViewItem();

                item.Text = row["Name"].ToString();
                item.SubItems.Add(row["Path"].ToString());
                item.SubItems.Add(row["Parameter"].ToString());
                item.SubItems.Add(row["Shortcut"].ToString());
                item.SubItems.Add(row["Shorthand"].ToString());
                SpecialIcons(row, item); // EasterEgg


                lvShortcuts.Items.Add(item); //Add this row to the ListView

            }


            int ButtonEndPoint = btnNew.Location.X + btnNew.Width + 25;




            lvShortcuts.Columns[0].Width = -2; // -2 Heißt Achte auf ColumnHeader und Content 
            lvShortcuts.Columns[1].Width = -2;
            lvShortcuts.Columns[2].Width = -2;
            lvShortcuts.Columns[3].Width = -2;
            lvShortcuts.Columns[4].Width = 65;
            if (lvShortcuts.Columns[1].Width > 400) { lvShortcuts.Columns[1].Width = 400; } // PFAD zu Lange Streckt das Programm sonst zu krass
            if (lvShortcuts.Columns[2].Width > 110) { lvShortcuts.Columns[2].Width = 110; } // Ekliger Parameter Incoming #Bla 


            sclFormWidth = lvShortcuts.Columns[0].Width + lvShortcuts.Columns[1].Width +
                             lvShortcuts.Columns[2].Width + lvShortcuts.Columns[3].Width
              + lvShortcuts.Columns[4].Width + 16;
            if (sclFormWidth < ButtonEndPoint)
            {
                sclFormWidth = ButtonEndPoint;
                lvShortcuts.Columns[4].Width = ButtonEndPoint - lvShortcuts.Columns[0].Width - lvShortcuts.Columns[1].Width -
                    lvShortcuts.Columns[2].Width - lvShortcuts.Columns[3].Width;
            }
            lvShortcuts.Width = sclFormWidth;

        }
        /// <summary>
        /// Fügt EasterEggs ABER auch sinnvolle Icons zu Speziellen Zeilen hinzu :3
        /// </summary>
        /// <param name="row">Die Zeilen des DataTalbs</param>
        /// <param name="item">Das ListviewItem</param>
        private void SpecialIcons(DataRow row, ListViewItem item)
        {

            // Wenn das Objekt Existiert egal ob es eine Datei oder ein Ordner ist
            if (System.IO.File.Exists(row["Path"].ToString()) || System.IO.Directory.Exists(row["Path"].ToString()))
            {

                // Wenn das Objekt eine Datei ist 
                if (System.IO.File.Exists(row["Path"].ToString()))
                {
                    imgList.Images.Add(row["Name"].ToString(), ico.ExtractAssociatedIconEx(row["Path"].ToString()));
                    item.ImageIndex = imgList.Images.Count - 1; // + Wie viele Festdefinierte Bilder

                    if (row["Path"].ToString().EndsWith(".mp4")) { item.ImageIndex = 4; } //4 Weil immer ein Element hier hinzugefügt obwohl 5 Datei im Ordner
                    if (row["Path"].ToString().EndsWith(".mp3")) { item.ImageIndex = 5; }

                }

                // Wenn das Objekt ein Ordner ist 
                if (System.IO.Directory.Exists(row["Path"].ToString()))
                {
                    item.ImageIndex = 0;  // + Wie viele Festdefinierte Bilder 
                                          // INDEX UMÄNDERN MIT NAME AM BESTEN  rfhwe8ufh 


                }
            }
            else { item.ImageIndex = 2; };


            //Webseiten NOCH BEARBWITEN
            if (row["Path"].ToString().Contains("http://")) { item.ImageKey = "Web"; }









            //Porn Icon //MUSS ZULETZT STEHEN DA EASTEREGG
            //if (row["Name"].ToString().Contains("Porn")) { item.ImageKey = "Porn"; }
            //if (row["Path"].ToString().Contains("porn")) { item.ImageKey = "Porn"; }
            //
        }






        /// <summary>
        /// Befüllt die Checkbox mit den ensprechenden Werten und liegt ihre Autovervollständigung fest. 
        /// </summary>
        private void LoadSearch()
        {
            for (int i = 0; i < lvShortcuts.Columns.Count; i++) { cBoxSearchType.Items.Add(lvShortcuts.Columns[i].Text); }
            cBoxSearchType.Text = cBoxSearchType.Items[0].ToString();
            cBoxSearchType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cBoxSearchType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

        }






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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }


        private void lvShortcuts_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            Edit edt = new Edit(lv.SelectedItems[0].Text, lv.SelectedItems[0].SubItems[1].Text, lv.SelectedItems[0].SubItems[2].Text, lv.SelectedItems[0].SubItems[3].Text, lv.SelectedItems[0].SubItems[4].Text);
            edt.Show();
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
            Edit edt = new Edit(Functions.DDFileName, Functions.DDPath, "", "", "");
            edt.Show();


        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            if ( Functions.IsFormOpend("Edit") == false )
            {
                Edit edt = new Edit(Functions.DDFileName, Functions.DDPath, "", "", "");
                edt.Show();
            }
            else
            {
                // Application.OpenForms
            }
         

        }
    }


}






