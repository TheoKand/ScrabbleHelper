using System;
using System.Drawing;

using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ScrabbleHelper2
{
    partial class frmScrabbleHelper
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScrabbleHelper));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.LinkLabel();
            this.chkCritMustBeNew4 = new System.Windows.Forms.CheckBox();
            this.chkCritMustBeNew3 = new System.Windows.Forms.CheckBox();
            this.chkCritMustBeNew2 = new System.Windows.Forms.CheckBox();
            this.chkCritMustBeNew1 = new System.Windows.Forms.CheckBox();
            this.txtCritLetter4 = new System.Windows.Forms.TextBox();
            this.cboCritType4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCritLetter3 = new System.Windows.Forms.TextBox();
            this.cboCritType3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCritLetter2 = new System.Windows.Forms.TextBox();
            this.cboCritType2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCritLetter1 = new System.Windows.Forms.TextBox();
            this.cboCritType1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkNoAdditional = new System.Windows.Forms.CheckBox();
            this.txtLetters = new System.Windows.Forms.TextBox();
            this.lblLettersYouHave = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.progress1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblSortOnPos = new System.Windows.Forms.Label();
            this.lblSortOnValue = new System.Windows.Forms.Label();
            this.lblSortOnLength = new System.Windows.Forms.Label();
            this.lblSortOnNewLetters = new System.Windows.Forms.Label();
            this.lblSortOnWord = new System.Windows.Forms.Label();
            this.lblSortOnWordInversed = new System.Windows.Forms.Label();
            this.ResultsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowWords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.ResultsMenu.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.chkCritMustBeNew4);
            this.groupBox1.Controls.Add(this.chkCritMustBeNew3);
            this.groupBox1.Controls.Add(this.chkCritMustBeNew2);
            this.groupBox1.Controls.Add(this.chkCritMustBeNew1);
            this.groupBox1.Controls.Add(this.txtCritLetter4);
            this.groupBox1.Controls.Add(this.cboCritType4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCritLetter3);
            this.groupBox1.Controls.Add(this.cboCritType3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCritLetter2);
            this.groupBox1.Controls.Add(this.cboCritType2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCritLetter1);
            this.groupBox1.Controls.Add(this.cboCritType1);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Name = "btnClear";
            this.btnClear.TabStop = true;
            this.btnClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClear_LinkClicked);
            // 
            // chkCritMustBeNew4
            // 
            resources.ApplyResources(this.chkCritMustBeNew4, "chkCritMustBeNew4");
            this.chkCritMustBeNew4.Name = "chkCritMustBeNew4";
            // 
            // chkCritMustBeNew3
            // 
            resources.ApplyResources(this.chkCritMustBeNew3, "chkCritMustBeNew3");
            this.chkCritMustBeNew3.Name = "chkCritMustBeNew3";
            // 
            // chkCritMustBeNew2
            // 
            resources.ApplyResources(this.chkCritMustBeNew2, "chkCritMustBeNew2");
            this.chkCritMustBeNew2.Name = "chkCritMustBeNew2";
            // 
            // chkCritMustBeNew1
            // 
            resources.ApplyResources(this.chkCritMustBeNew1, "chkCritMustBeNew1");
            this.chkCritMustBeNew1.Name = "chkCritMustBeNew1";
            // 
            // txtCritLetter4
            // 
            this.txtCritLetter4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtCritLetter4, "txtCritLetter4");
            this.txtCritLetter4.Name = "txtCritLetter4";
            this.txtCritLetter4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetters_KeyPress);
            // 
            // cboCritType4
            // 
            this.cboCritType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCritType4.Items.AddRange(new object[] {
            resources.GetString("cboCritType4.Items"),
            resources.GetString("cboCritType4.Items1"),
            resources.GetString("cboCritType4.Items2"),
            resources.GetString("cboCritType4.Items3"),
            resources.GetString("cboCritType4.Items4"),
            resources.GetString("cboCritType4.Items5"),
            resources.GetString("cboCritType4.Items6"),
            resources.GetString("cboCritType4.Items7")});
            resources.ApplyResources(this.cboCritType4, "cboCritType4");
            this.cboCritType4.Name = "cboCritType4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtCritLetter3
            // 
            this.txtCritLetter3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtCritLetter3, "txtCritLetter3");
            this.txtCritLetter3.Name = "txtCritLetter3";
            this.txtCritLetter3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetters_KeyPress);
            // 
            // cboCritType3
            // 
            this.cboCritType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCritType3.Items.AddRange(new object[] {
            resources.GetString("cboCritType3.Items"),
            resources.GetString("cboCritType3.Items1"),
            resources.GetString("cboCritType3.Items2"),
            resources.GetString("cboCritType3.Items3"),
            resources.GetString("cboCritType3.Items4"),
            resources.GetString("cboCritType3.Items5"),
            resources.GetString("cboCritType3.Items6"),
            resources.GetString("cboCritType3.Items7")});
            resources.ApplyResources(this.cboCritType3, "cboCritType3");
            this.cboCritType3.Name = "cboCritType3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtCritLetter2
            // 
            this.txtCritLetter2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtCritLetter2, "txtCritLetter2");
            this.txtCritLetter2.Name = "txtCritLetter2";
            this.txtCritLetter2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetters_KeyPress);
            // 
            // cboCritType2
            // 
            this.cboCritType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCritType2.Items.AddRange(new object[] {
            resources.GetString("cboCritType2.Items"),
            resources.GetString("cboCritType2.Items1"),
            resources.GetString("cboCritType2.Items2"),
            resources.GetString("cboCritType2.Items3"),
            resources.GetString("cboCritType2.Items4"),
            resources.GetString("cboCritType2.Items5"),
            resources.GetString("cboCritType2.Items6"),
            resources.GetString("cboCritType2.Items7")});
            resources.ApplyResources(this.cboCritType2, "cboCritType2");
            this.cboCritType2.Name = "cboCritType2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtCritLetter1
            // 
            this.txtCritLetter1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtCritLetter1, "txtCritLetter1");
            this.txtCritLetter1.Name = "txtCritLetter1";
            this.txtCritLetter1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetters_KeyPress);
            // 
            // cboCritType1
            // 
            this.cboCritType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCritType1.Items.AddRange(new object[] {
            resources.GetString("cboCritType1.Items"),
            resources.GetString("cboCritType1.Items1"),
            resources.GetString("cboCritType1.Items2"),
            resources.GetString("cboCritType1.Items3"),
            resources.GetString("cboCritType1.Items4"),
            resources.GetString("cboCritType1.Items5"),
            resources.GetString("cboCritType1.Items6"),
            resources.GetString("cboCritType1.Items7")});
            resources.ApplyResources(this.cboCritType1, "cboCritType1");
            this.cboCritType1.Name = "cboCritType1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // chkNoAdditional
            // 
            this.chkNoAdditional.Checked = true;
            this.chkNoAdditional.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkNoAdditional, "chkNoAdditional");
            this.chkNoAdditional.Name = "chkNoAdditional";
            // 
            // txtLetters
            // 
            this.txtLetters.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtLetters, "txtLetters");
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLetters_KeyPress);
            // 
            // lblLettersYouHave
            // 
            resources.ApplyResources(this.lblLettersYouHave, "lblLettersYouHave");
            this.lblLettersYouHave.Name = "lblLettersYouHave";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSearch
            // 
            resources.ApplyResources(this.cmdSearch, "cmdSearch");
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // statusBar1
            // 
            resources.ApplyResources(this.statusBar1, "statusBar1");
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.SizingGrip = false;
            // 
            // statusBarPanel1
            // 
            resources.ApplyResources(this.statusBarPanel1, "statusBarPanel1");
            // 
            // progress1
            // 
            resources.ApplyResources(this.progress1, "progress1");
            this.progress1.Name = "progress1";
            // 
            // lblSortOnPos
            // 
            resources.ApplyResources(this.lblSortOnPos, "lblSortOnPos");
            this.lblSortOnPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSortOnPos.Name = "lblSortOnPos";
            this.toolTip1.SetToolTip(this.lblSortOnPos, resources.GetString("lblSortOnPos.ToolTip"));
            this.lblSortOnPos.Click += new System.EventHandler(this.SortOnPosition);
            // 
            // lblSortOnValue
            // 
            resources.ApplyResources(this.lblSortOnValue, "lblSortOnValue");
            this.lblSortOnValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSortOnValue.Name = "lblSortOnValue";
            this.toolTip1.SetToolTip(this.lblSortOnValue, resources.GetString("lblSortOnValue.ToolTip"));
            this.lblSortOnValue.Click += new System.EventHandler(this.lblSortOnValue_Click);
            // 
            // lblSortOnLength
            // 
            resources.ApplyResources(this.lblSortOnLength, "lblSortOnLength");
            this.lblSortOnLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSortOnLength.Name = "lblSortOnLength";
            this.toolTip1.SetToolTip(this.lblSortOnLength, resources.GetString("lblSortOnLength.ToolTip"));
            this.lblSortOnLength.Click += new System.EventHandler(this.lblSortOnLength_Click);
            // 
            // lblSortOnNewLetters
            // 
            resources.ApplyResources(this.lblSortOnNewLetters, "lblSortOnNewLetters");
            this.lblSortOnNewLetters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSortOnNewLetters.Name = "lblSortOnNewLetters";
            this.toolTip1.SetToolTip(this.lblSortOnNewLetters, resources.GetString("lblSortOnNewLetters.ToolTip"));
            this.lblSortOnNewLetters.Click += new System.EventHandler(this.lblSortOnNewLetters_Click);
            // 
            // lblSortOnWord
            // 
            resources.ApplyResources(this.lblSortOnWord, "lblSortOnWord");
            this.lblSortOnWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSortOnWord.Name = "lblSortOnWord";
            this.toolTip1.SetToolTip(this.lblSortOnWord, resources.GetString("lblSortOnWord.ToolTip"));
            this.lblSortOnWord.Click += new System.EventHandler(this.lblSortOnWord_Click);
            // 
            // lblSortOnWordInversed
            // 
            this.lblSortOnWordInversed.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblSortOnWordInversed, "lblSortOnWordInversed");
            this.lblSortOnWordInversed.Name = "lblSortOnWordInversed";
            this.toolTip1.SetToolTip(this.lblSortOnWordInversed, resources.GetString("lblSortOnWordInversed.ToolTip"));
            this.lblSortOnWordInversed.Click += new System.EventHandler(this.lblSortOnWordInversed_Click);
            // 
            // ResultsMenu
            // 
            this.ResultsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteMenuItem});
            this.ResultsMenu.Name = "menu1";
            resources.ApplyResources(this.ResultsMenu, "ResultsMenu");
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            resources.ApplyResources(this.DeleteMenuItem, "DeleteMenuItem");
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions,
            this.mnuHelp});
            resources.ApplyResources(this.mnuMain, "mnuMain");
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuShowWords,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuOptions.Name = "mnuOptions";
            resources.ApplyResources(this.mnuOptions, "mnuOptions");
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            resources.ApplyResources(this.mnuSettings, "mnuSettings");
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuShowWords
            // 
            this.mnuShowWords.Name = "mnuShowWords";
            resources.ApplyResources(this.mnuShowWords, "mnuShowWords");
            this.mnuShowWords.Click += new System.EventHandler(this.mnuShowWords_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            resources.ApplyResources(this.mnuExit, "mnuExit");
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInstructions,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            resources.ApplyResources(this.mnuHelp, "mnuHelp");
            // 
            // mnuInstructions
            // 
            this.mnuInstructions.Name = "mnuInstructions";
            resources.ApplyResources(this.mnuInstructions, "mnuInstructions");
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            resources.ApplyResources(this.mnuAbout, "mnuAbout");
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            // 
            // rtbText
            // 
            resources.ApplyResources(this.rtbText, "rtbText");
            this.rtbText.Name = "rtbText";
            this.rtbText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbText_MouseDown);
            // 
            // frmScrabbleHelper
            // 
            this.AcceptButton = this.cmdSearch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.cmdCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.progress1);
            this.Controls.Add(this.lblSortOnPos);
            this.Controls.Add(this.lblSortOnNewLetters);
            this.Controls.Add(this.lblSortOnValue);
            this.Controls.Add(this.lblSortOnLength);
            this.Controls.Add(this.lblSortOnWord);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblSortOnWordInversed);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.chkNoAdditional);
            this.Controls.Add(this.lblLettersYouHave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLetters);
            this.Name = "frmScrabbleHelper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScrabbleHelper_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResultsMenu.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private LinkLabel btnClear;
        private CheckBox chkCritMustBeNew4;
        private CheckBox chkCritMustBeNew3;
        private CheckBox chkCritMustBeNew2;
        private CheckBox chkCritMustBeNew1;
        private TextBox txtCritLetter4;
        private ComboBox cboCritType4;
        private Label label5;
        private TextBox txtCritLetter3;
        private ComboBox cboCritType3;
        private Label label4;
        private TextBox txtCritLetter2;
        private ComboBox cboCritType2;
        private Label label3;
        private TextBox txtCritLetter1;
        private ComboBox cboCritType1;
        private Label label2;
        private CheckBox chkNoAdditional;
        private TextBox txtLetters;
        private Label lblLettersYouHave;
        private Button cmdCancel;
        private Button cmdSearch;
        private StatusBar statusBar1;
        private StatusBarPanel statusBarPanel1;
        private ProgressBar progress1;
        private ToolTip toolTip1;
        private ContextMenuStrip ResultsMenu;
        private ToolStripMenuItem DeleteMenuItem;
        private Label lblSortOnPos;
        private Label lblSortOnValue;
        private Label lblSortOnLength;
        private Label lblSortOnNewLetters;
        private Label lblSortOnWord;
        private Label lblSortOnWordInversed;
        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuOptions;
        private ToolStripMenuItem mnuSettings;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuInstructions;
        private ToolStripMenuItem mnuAbout;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuShowWords;
        private ToolStripSeparator toolStripMenuItem1;
        private WebBrowser webBrowser1;
        private RichTextBox rtbText;


    }
}