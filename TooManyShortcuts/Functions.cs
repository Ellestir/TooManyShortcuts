/*
 * Created by SharpDevelop.
 * User: r401-fobi1
 * Date: 03.12.2015
 * Time: 07:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Win32;

namespace TooManyShortcuts
{

    /// <summary>
    /// Description of HotKeyFunctions.
    /// </summary>

    public static class Functions
    {



        public static bool forminwork = false;
        static KeyMods KeyMod = new KeyMods();
        public static string DDFileName = ""; // DragDropFileName 
        public static string DDPath; //DragDropPath
        public static KeyboardHook hook = new KeyboardHook();
        public static XMLShortcutList XMLListTemp;
        public static RegistryKey rkStartUp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public static RegistryKey rkDisabledStartUp;
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);



        // this gives you the handle of the window you need.

        // then use this handle to bring the window to focus or forground(I guessed you wanted this).

        // sometimes the window may be minimized and the setforground function cannot bring it to focus so:

        /*use this ShowWindow(IntPtr handle, int nCmdShow);
        *there are various values of nCmdShow 3, 5 ,9. What 9 does is: 
        *Activates and displays the window. If the window is minimized or maximized, *the system restores it to its original size and position. An application *should specify this flag when restoring a minimized window */

      
        /// <summary>
        /// Notwendig um Shortcuts registrieren zu können!
        /// </summary>
        public static void IntalizeKeyPressEvent(XMLShortcutList XMLList)
        {
            XMLListTemp = XMLList;
            hook.KeyPressed +=
                  new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
        }


        public static void RegisterHotKey(string completeshortcut)
        {
            if (completeshortcut.Split('+')[0] == "STRG ") KeyMod = KeyMods.Control;
            if (completeshortcut.Split('+')[0] == "ALT ") KeyMod = KeyMods.Alt;
            if (completeshortcut.Split('+')[0] == "SHIFT ") KeyMod = KeyMods.Shift;

            string tempstr = completeshortcut.Split('+')[1];
            tempstr = tempstr.Substring(1, tempstr.Length - 1);
            Application.DoEvents();




            hook.RegisterHotKey(KeyMod, (Keys)Enum.Parse(typeof(Keys), tempstr));

        }



        //Hotkeyausführung: Falls der Hotkey gedrückt wird müssen einige Zeichen umgewandelt werden 
        static void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Application.DoEvents(); 
            string Mod = "";
            if (e.Modifier.ToString() == "Control") { Mod = "STRG"; } //Umwandelung um eine Abfrage mit der Liste durchzuführen
            else if (e.Modifier.ToString() == "Alt") { Mod = "ALT"; } // --
            else if (e.Modifier.ToString() == "Shift") { Mod = "SHIFT"; } // --


            //Falls STRG und Leertaste gedrückt werden wird das ShorthandWindow aufgerufen
            if (Mod == "STRG" && e.Key.ToString() == "Space")
            {
                ShorthandWindow shw = new ShorthandWindow(XMLListTemp);
                shw.Name = "ShorthandWindow"; 
                if (Application.OpenForms["ShorthandWindow"] == null) 
                {
                    shw.Show();

                    ShowWindow(FindWindow("ShorthandWindow", null), 9);

                    SetForegroundWindow(FindWindow("ShorthandWindow", null));
                }
                else
                {
                    Application.OpenForms["ShorthandWindow"].Focus();
                }
              


            }
            foreach (Shortcut sc in XMLListTemp.Shortcuts)
            { // Durchsuche die Erste Dimension (Alle Items ohne Subitem) 
                ListViewItem item = new ListViewItem();

                if (Mod + " + " + e.Key.ToString() == sc.Keycombo)
                { //Ist das 3 Subitem (gespeicherte Tastenkombi) mit der Tastenkombination gleich {
                    StartProcess(sc);

                }
                
            }
           
        }

     

        /// <summary>
        /// Fill ImgList with Picture from a Directory.
        /// </summary>
        /// <param name="folderpath"> Foldername</param>
        /// <param name="imgList"> Which ImgList should be filled</param>
        /// <param name="filter">searchPatter like "*.png" or "*.jpg"</param>
        public static void FillImageList(string folderpath, ImageList imgList, string filter)
        {
            foreach (string path in System.IO.Directory.GetFiles(folderpath, filter, System.IO.SearchOption.AllDirectories))
            {
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                name = name.Substring(0, name.Length - 4);

                imgList.Images.Add(name, System.Drawing.Image.FromFile(path));

            }
        }


        public static void StartProcess(Shortcut sc)
        {


            

            if (sc.Path == "Text")
            {
                Application.DoEvents();
                Thread.Sleep(200);
                Clipboard.SetText(sc.Parameters, TextDataFormat.UnicodeText);
                SendKeys.Send("^{v}");

            }

            else
            {
                ProcessStartInfo ProcessInfo = new ProcessStartInfo();
                ProcessInfo.FileName = sc.Path;
                ProcessInfo.Arguments = sc.Parameters; //Zuweißung des Parameters aus der Liste
                try
                {
                    Process.Start(ProcessInfo);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                }                                                   


            }




        }


        /// <summary>
        /// Setzt den Autostart des Programms fest bzw ändert ihn 
        /// </summary>
        /// <param name="objchecked">Eine gecheckte Textbox etc. Lediglich false oder true Mitgabe</param>
        public static void SetWindowsStartUp(bool objchecked)
        {
            CheckWindowsStartUp(); 

            if (objchecked)
            {
                rkDisabledStartUp.DeleteValue("StartUp", false);
                rkStartUp.SetValue("StartUp", Application.ExecutablePath.ToString());
               
            }
            else
            {
                rkStartUp.DeleteValue("StartUp", false);
                rkDisabledStartUp.SetValue("StartUp", Application.ExecutablePath.ToString());

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>FirstStart = Erster Start des Programms // </returns>
        public static string CheckWindowsStartUp()
        {
            rkStartUp.CreateSubKey("Disabled");
            rkDisabledStartUp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\Disabled", true);


            if (rkStartUp.GetValue("StartUp") == null)
            {

                if (rkDisabledStartUp.GetValue("StartUp") == null)
                {
                    return "firststart";
                }
                else
                {
                    return "deactivated";
                }
            }
            else
            {
                return "activated";
            }

        }
 

        static public Bitmap getIcon(string path)
        {
            try
            {
                Bitmap b = Icon.ExtractAssociatedIcon(path).ToBitmap();
                return b;
            }
            catch (Exception e)
            {
                MessageBox.Show("Die folgende Datei ist nicht vorhanden oder hat nicht das richtige Format: " + e.Message);
                return null;
            }
        }


        /// <summary>
        /// Drag Drop Methode Teil 1
        /// </summary>
        /// <param name="e"></param>
        public static void FileDragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) | e.Data.GetDataPresent(typeof(string)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }


        /// <summary>
        /// Drag Drop Methode Teil 2. 
        /// </summary>
        /// <param name="e"></param>
        public static void FileDragDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                string s = FileList[0];


                if (s.Substring(s.LastIndexOf("\\"), s.Length - s.LastIndexOf("\\")).Contains("."))
                {
                    DDFileName = s.Substring(s.LastIndexOf("\\") + 1, s.LastIndexOf(".") - s.LastIndexOf("\\") - 1);
                }
                else { DDFileName = s.Substring(s.LastIndexOf("\\") + 1, s.Length - s.LastIndexOf("\\") - 1); }
                DDPath = s; 
            }
            else if (e.Data.GetDataPresent(typeof(string)))
            {
                DDPath = (string)e.Data.GetData(typeof(string));
            }
            {

            }
            
        }

    }


}

