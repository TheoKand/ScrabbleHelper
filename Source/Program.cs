using System;
using System.Drawing;
using ScrabbleHelper2.Properties;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace ScrabbleHelper2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ////create key in registry if valid user
            //DateTime date1 = new DateTime(2007, 11, 7, 1, 0, 0);
            //DateTime date2 = DateTime.Now;
            //TimeSpan span = date2 - date1;
            //if (span.Hours < 2)
            //{
            //    Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\MyKey", "somevalue", "1");
            //} else {
            //    //check for valid key in registry
            //    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\MyKey", "somevalue", "")==null) {
            //        MessageBox.Show("Contact theok@in.gr if you want to use this program.");
            //        return;
            //    }
            //    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\MyKey", "somevalue", "").ToString()  != "1")
            //    {
            //        MessageBox.Show("Contact theok@in.gr if you want to use this program.");
            //        return;
            //    }

            //}

            //give default values to settings if program is executed for first time
            if (Settings.Default.Language.Length == 0)
                Settings.Default.Language = "en";

            Settings.Default.WordsFile = Utils.GetWordsFile();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.Language);

            Application.Run(new frmScrabbleHelper());




            


        }
    }




}