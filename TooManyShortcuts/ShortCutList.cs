using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
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
        string ProgramIconPath = Application.StartupPath + "\\Icons";


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
            // Initizalisierung des KeyPressEvents wie Registrieren von ShorthandWindows durch STRG + Space
            Functions.IntalizeKeyPressEvent(XMLList);


            
            

            //Icons

            // Drag an Drop Events 
            lvShortcuts.AllowDrop = true;
            lvShortcuts.DragEnter += new DragEventHandler(lvShortcuts_DragEnter);
            lvShortcuts.DragDrop += new DragEventHandler(lvShortcuts_DragDrop);
            imgList.ImageSize = new System.Drawing.Size(40, 40); //40 Item Größe


            // Imagelist wird befüllt 
            //Functions.FillImageList(ProgramIconPath, imgList, "*.png");
            imgList.Images.Add("C", Properties.Resources.C);
            imgList.Images.Add("Folder", Properties.Resources.Folder);
            imgList.Images.Add("Music", Properties.Resources.Music);
            imgList.Images.Add("Pictures", Properties.Resources.Pictures);
            imgList.Images.Add("Videos", Properties.Resources.Videos);
            imgList.Images.Add("Web", Properties.Resources.Web);
            imgList.Images.Add("Error", Properties.Resources.Error);
            imgList.Images.Add("Text", Properties.Resources.Text);

            // Listview Einstellungen
            lvShortcuts.FullRowSelect = true;
            lvShortcuts.LargeImageList = imgList;
            lvShortcuts.SmallImageList = imgList;
            lvShortcuts.GridLines = true;
            lvShortcuts.MultiSelect = false;
            // Lösch Button wird disabled
            btnDelete.Enabled = false;



            // Hier Sprache festlegen 

            UpdateShortcuts();


            txtSearch.Focus();

            

        }

        /// <summary>
        /// Updatet die XMLList, schreibt diese in die XML Datei, befüllt das List view Element sowie legt die Column Größen fest. 
        /// </summary>
        /// <param name="edt">Beim Systemstart nichts übergeben bei Änderungen die entsprechende Edt Form mit übergeben um XMLList zu überschreiben</param>
        public void UpdateShortcuts([Optional] Edit edt)
        {
            


            bool stop = false; 
            // Wenn edt mitgebenen wird  dann wird die jetzige XML List  von der edt List überschrieben.
            if (edt != null)
            {
                if (edt.ShowDialog(this) == DialogResult.OK)
                {
                    
                    XMLList = edt.XMLListTemp;
                }
                else
                {
                    
                    stop = true; 
                }
            }

            if (!stop)
            {
                Functions.RegisterHotKey("STRG + Space");
                lvShortcuts.Items.Clear();

                try
                {
                    ListSerializer.DeSerialize(XMLList, XMLPath);
                    // Durchläuft Schleifer aller Shortcuts und registriert jeden Shortcut erneut da diese in der edt Form gelöscht wurden. 
                    // Weiterhin werden ListviewItems zur Listview hinzugefügt und mit Spezialen Icons versehen. 
                    RegisterAllShortcuts(); 
                    foreach (Shortcut sc in XMLList.Shortcuts)
                    {

                        ListViewItem item = new ListViewItem();

                        item.Text = sc.Name;


                        item.SubItems.Add(sc.Path);
                        item.SubItems.Add(sc.Parameters);
                        item.SubItems.Add(sc.Keycombo);
                        item.SubItems.Add(sc.Shorthand);
                        SpecialIcons(sc, item); // EasterEgg
                        lvShortcuts.Items.Add(item); //Add this row to the ListView

                    }


                }
                catch
                {

                }



                // Column Größe festlegen 
                if (lvShortcuts.Items.Count == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        lvShortcuts.Columns[i].Width = lvShortcuts.Width / 5;
                    }
                }
                else
                {
                    lvShortcuts.Columns[0].Width = 148;
                    lvShortcuts.Columns[1].Width = 148;
                    lvShortcuts.Columns[2].Width = 80;
                    lvShortcuts.Columns[3].Width = 80;
                    lvShortcuts.Columns[4].Width = 80; // -2 Heißt Achte auf ColumnHeader und Content 



                }
                txtSearch.Text = txtSearch.Text;

            }

        }

        public void RegisterAllShortcuts()
        {
            foreach (Shortcut sc in XMLList.Shortcuts)
            {
                Functions.RegisterHotKey(sc.Keycombo);
            }
        }
        /// <summary>
        /// Fügt EasterEggs aber auch sinnvolle Icons zu Speziellen Zeilen hinzu :3
        /// </summary>
        /// <param name="sc">Die Zeilen des DataTalbs</param>
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

                    if (sc.Path.EndsWith(".mp4")) { item.ImageKey = "Videos"; } //4 Weil immer ein Element hier hinzugefügt obwohl 5 Datei im Ordner
                    if (sc.Path.EndsWith(".mp3")) { item.ImageKey = "Music"; }
                    if (sc.Path.EndsWith(".png") || sc.Path.EndsWith(".jpg")) { item.ImageKey = "Pictures"; }
                }

                // Wenn das Objekt ein Ordner ist 
                if (System.IO.Directory.Exists(sc.Path))
                {
                    if (sc.Path == ("C:\\")) { item.ImageKey = "C"; }
                    else if (sc.Path == ("D:\\")) { item.ImageKey = "C"; }
                    else
                    {
                        item.ImageKey = "Folder";
                    }




                }
            }
            else if (sc.Path == "Text")
            {
                item.ImageKey = "Text";
            }
            else { item.ImageKey = "Error"; };


            if (sc.Path.Contains("http") || sc.Path.Contains("www"))
            {
                           
                    item.ImageKey = "Web";
               

            }

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
                if (Regex.IsMatch(sc.Name, txtSearch.Text, RegexOptions.IgnoreCase) || Regex.IsMatch(sc.Path, txtSearch.Text, RegexOptions.IgnoreCase) || Regex.IsMatch(sc.Shorthand, txtSearch.Text, RegexOptions.IgnoreCase))
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



                        }
                    }
                    lvShortcuts.Items.Add(item); //Add this row to the ListView

                }


            }
        }

        private void lvShortcuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                DeleteShortcut();
            }
        }

        private void lvShortcuts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvShortcuts.SelectedItems.Count == 0)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteShortcut();
        }

        private void DeleteShortcut()
        {
            try
            {
                XMLList.Shortcuts.Remove(XMLList.Shortcuts.Find((x => x.Name == lvShortcuts.SelectedItems[0].Text)));
                lvShortcuts.SelectedItems[0].Remove();
                ListSerializer.Serialize(XMLList, XMLPath);
                Functions.hook.Dispose();
                
                UpdateShortcuts();
            }
            catch (Exception)
            {

                MessageBox.Show("Kein Element ausgewählt!");
            }
        }

    }
}









