﻿/*
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
        //Registert den Hotkey 
        public static void RegisterHotKey(string completeshortcut)
        {
            if (completeshortcut.Split('+')[0] == "STRG ") KeyMod = KeyMods.Control;
            if (completeshortcut.Split('+')[0] == "ALT ") KeyMod = KeyMods.Alt;
            if (completeshortcut.Split('+')[0] == "SHIFT ") KeyMod = KeyMods.Alt;

            string tempstr = completeshortcut.Split('+')[1];
            tempstr = tempstr.Substring(1, tempstr.Length - 1);
            Application.DoEvents();


            KeyboardHook hook = new KeyboardHook();
            hook.KeyPressed +=
                 new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(KeyMod, (Keys)Enum.Parse(typeof(Keys), tempstr));
        }

        //Hotkeyausführung: Falls der Hotkey gedrückt wird müssen einige Zeichen umgewandelt werden 
        static void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            string Mod = "";
            if (e.Modifier.ToString() == "Control") { Mod = "STRG"; } //Umwandelung um eine Abfrage mit der Liste durchzuführen
            else if (e.Modifier.ToString() == "Alt") { Mod = "ALT"; } // --
            else if (e.Modifier.ToString() == "Shift") { Mod = "SHIFT"; } // --


            //Falls STRG und Leertaste gedrückt werden wird das ShorthandWindow aufgerufen
            if (Mod == "STRG" && e.Key.ToString() == "Space")
            {
                ShorthandWindow shw = new ShorthandWindow();
                CreatePopUpForm(shw);
                
            }
            foreach (DataRow row in ShortCutList.ShortCutTable.Rows)
            { // Durchsuche die Erste Dimension (Alle Items ohne Subitem) 
                ListViewItem item = new ListViewItem();

                if (Mod + " + " + e.Key.ToString() == row["Shortcut"].ToString())
                { //Ist das 3 Subitem (gespeicherte Tastenkombi) mit der Tastenkombination gleich {
                    StartProcess(row);

                }

            }
        }

        public static void CreatePopUpForm(Form f)
        {

            if (forminwork == false)
            {
                f.Show();
                f.Focus();  
                forminwork = true;
            }

        }
      
        /// <summary>
        /// Fill ImgList with Picture from a Directory.
        /// </summary>
        /// <param name="folderpath"> Foldername</param>
        /// <param name="imgList"> Which ImgList should be filled</param>
        /// <param name="filter">searchPatter like "*.png" or "*.jpg"</param>
        public static void FillImageList(string folderpath,ImageList imgList, string filter)
        {
            foreach (string path in System.IO.Directory.GetFiles(folderpath, filter,System.IO.SearchOption.AllDirectories))
            {
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                name = name.Substring(0, name.Length - 4);

                imgList.Images.Add(name, System.Drawing.Image.FromFile(path));

            }
        }

        public static bool IsFormOpend(string FormName)
        {

            foreach (Form frm in Application.OpenForms)
            {
              if (frm.Name == FormName) {
                    return true;
                    
                }
               
            }
           return false;
        }

        public static void StartProcess(DataRow row)
        {




            if (row["Path"].ToString() == "Text" ) 
            {
             //   Application.DoEvents();
           //     Thread.Sleep(200); 
           //     SendKeys.Send("TEST");
      
            } 

            else
            {
                ProcessStartInfo ProcessInfo = new ProcessStartInfo();
                ProcessInfo.FileName = row["Path"].ToString();
                ProcessInfo.Arguments = row["Parameter"].ToString(); //Zuweißung des Parameters aus der Liste
                                                                     // ProcessInfo.WindowStyle = ProcessWindowStyle.Normal;                                                // WICHTIG ProcessInfo.WindowStyle = ProcessWindowStyle.Maximized; // Usefull Pls Add an Option to the origin Program
                Process.Start(ProcessInfo);

            }




        }
       

        /// <summary>
        /// Setzt den Autostart des Programms fest bzw ändert ihn 
        /// </summary>
        /// <param name="objchecked">Eine gecheckte Textbox etc. Lediglich false oder true Mitgabe</param>
        public static void StartAtWindowsStartUp(bool objchecked)
        {
            RegistryKey rkPath = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (objchecked) { rkPath.SetValue("StartUp", Application.ExecutablePath.ToString()); }
            else { rkPath.DeleteValue("StartUp", false);  }
        }



        /// <summary>
        /// Drag Drop Methode Teil 1
        /// </summary>
        /// <param name="e"></param>
        public static void FileDragEnter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
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
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string s = FileList[0];
            

            if (s.Substring(s.LastIndexOf("\\"), s.Length - s.LastIndexOf("\\")).Contains("."))
            {
                DDFileName = s.Substring(s.LastIndexOf("\\") + 1, s.LastIndexOf(".") - s.LastIndexOf("\\") - 1);
            }
            else { DDFileName = s.Substring(s.LastIndexOf("\\") + 1, s.Length - s.LastIndexOf("\\") - 1); }
            DDPath = s;
        }
        /// <summary>
        /// Kann durch die angabe des HandleWidnows die Postion dessen ändern. 
        /// </summary>
        /// <param name="hWnd">HandleWindow. Kann mit Process.Start (prc.MainWindowHandle) ermittelt werden</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="repaint"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);

        public static void WindowsLeftSide(IntPtr WindowHandle)
        {
            MoveWindow(WindowHandle, 0, 0, Screen.PrimaryScreen.WorkingArea.X / 2, Screen.PrimaryScreen.WorkingArea.Y, false);
        }
    }


}
