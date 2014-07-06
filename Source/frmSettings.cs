using ScrabbleHelper2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScrabbleHelper2
{
    public partial class frmSettings : Form
    {
        public System.Globalization.CultureInfo SelectedCulture;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmLanguage_Load(object sender, EventArgs e)
        {
            switch (Settings.Default.Language)
            {
                case "el":
                    lstLanguage.SelectedIndex = 0;
                    break;
                case "en":
                    lstLanguage.SelectedIndex = 1;
                    break;
            }

            chkTopMost.Checked=Settings.Default.TopMost;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.lstLanguage.SelectedIndex)
            {
                case 0:
                    SelectedCulture = new System.Globalization.CultureInfo("el");
                    Settings.Default.Language = "el";
                    break;
                case 1:
                    SelectedCulture = new System.Globalization.CultureInfo("en");
                    Settings.Default.Language = "en";
                    break;
            }

            //Apply selected language
            System.Threading.Thread.CurrentThread.CurrentUICulture = SelectedCulture;

            this.Owner.TopMost = chkTopMost.Checked;

            Settings.Default.WordsFile = Utils.GetWordsFile();
            Settings.Default.TopMost = chkTopMost.Checked;
            Settings.Default.Save();

            this.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}