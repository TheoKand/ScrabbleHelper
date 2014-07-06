using ScrabbleHelper2.Properties;
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
    public partial class frmScrabbleHelper : Form
    {
        public frmScrabbleHelper()
        {
            Utils.MakeTopMost(this, Settings.Default.TopMost);
            InitializeComponent();
        }

        //Struct used to save information about right click on the text box
        private struct RightClickInfo
        {
            public int CharIndex;
            public int LineIndex;
            public string Word;
        }

        private RightClickInfo rightClick = new RightClickInfo();

        private Alphabet alphabet;

        private string[] Letters = new string[7];
        private string[] WordArray;

        private List<ProposedWord> GlobalResults;

        private int GlobalResultCount;
        private bool Working = false;
        private Thread worker;

        private string TempFile = "";


        private bool WordsModified = false;

        /// <summary>
        /// Returns the number of letters that have been provided by the user. They can be
        /// from 1 to 7
        /// </summary>
        /// <returns></returns>
        private int GetLetterCount()
        {
            int RetVal = 0;
            for (int i = 0; i < Letters.Length; i++)
            {
                if (!((Letters[i] == null) || (Letters[i].Length == 0)))
                {
                    RetVal++;
                }
            }
            return RetVal;


        }

        private delegate void ShowResultsDelegate(List<ProposedWord> Results);

        private void ShowResultsInBrowser(List<ProposedWord> Results)
        {
            if (Results == null) return;
            webBrowser1.SuspendLayout();
            webBrowser1.Navigate("about:blank");

            //delete previous temp file
            if (TempFile.Length > 0)
            {
                try
                {
                    File.Delete(TempFile);
                }
                catch { }

            }

            InitBar(progress1, 0, Results.Count, 0);

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<html><head><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-7'></head><body leftmargin=2 topmargin=0 rightmargin=2 bottommargin=0><table width='100%' border=0 cellspacing=0 cellpadding=0 style='font-face:Courier New;font-size:15px;font-weight:bold'>");
            sb.Append("<tr><td height=1 width='33%'></td><td width='23%'></td><td width='18%'></td><td width='17%'></td><td></td></tr><tr><td height=3></td></tr>");

            for (int i = 0; i < Results.Count; i++)
            {
                SetBarValue(i);
                ProposedWord result = Results[i];

                string ColoredWord = result.Word;
                for (int x = 0; x < result.NewLetters.Count; x++)
                {
                    ColoredWord = ColoredWord.Replace(result.NewLetters[x], @"<font color='red'>" + result.NewLetters[x] + @"</font>");
                }

                string NewLetter = string.Join("", result.NewLetters.ToArray());
                string Length = result.Word.Length.ToString();
                string WordValue = result.Value.ToString();
                string Pos = result.NewLetterLocationDesc;

                sb.AppendFormat("<tr><td height=19 valign='top'>{0}</td><td valign='top' style='font-size:16px'>{1}</td><td valign='top' style='font-size:16px'>{2}</td><td valign='top' style='font-size:16px'>{3}</td><td valign='top' style='font-size:16px'>{4}</td>",
                    ColoredWord, NewLetter, Length, WordValue, Pos);

            }
            sb.Append(@"</table></body></html>");

            TempFile = Path.GetTempFileName();
            StreamWriter sr = new StreamWriter(TempFile, false, Encoding.UTF8);
            sr.Write(sb.ToString());
            sr.Close();

            webBrowser1.Navigate(TempFile);

            SetBarValue(progress1.Minimum);
        }

        private void ShowResultsInRTB(List<ProposedWord> Results)
        {
            if (Results == null) return;

            InitBar(progress1, 0, Results.Count, 0);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Results.Count; i++)
            {
                SetBarValue(i);
                ProposedWord result = Results[i];

                string ColoredWord = result.Word.PadRight(13);
                for (int x = 0; x < result.NewLetters.Count; x++)
                {
                    ColoredWord = ColoredWord.Replace(result.NewLetters[x], @"<startcolor>" + result.NewLetters[x] + @"<endcolor>");
                }

                string NewLetter = string.Join("", result.NewLetters.ToArray());
                string Length = result.Word.Length.ToString();
                string WordValue = result.Value.ToString();
                string Pos = result.NewLetterLocationDesc;

                //13	9	8	7	3
                sb.AppendFormat("{0}{1}{2}{3}{4}<BR>",
                    ColoredWord, NewLetter.PadRight(9), Length.PadRight(8), WordValue.PadRight(6), Pos.PadRight(3));

            }
            string rtf = Utils.HTMLToRTF("<B>" + sb.ToString() + "</B>");
            rtbText.Clear();
            rtbText.SuspendLayout();
            this.rtbText.Rtf = rtf;
            rtbText.SelectionStart = 0;
            SetBarValue(progress1.Minimum);
            rtbText.ResumeLayout();
            
                
        }

        private void ShowResults(List<ProposedWord> Results)
        {
            //ShowResultsInBrowser(Results);
            ShowResultsInRTB(Results);

        }


        /// <summary>
        /// Returns how many of the user's letters this word contains. Each of
        /// the user's letters only counts once
        /// </summary>
        /// <param name="Word">Word to check</param>
        /// <returns></returns>
        private int WordContainsThisManyLetters(string Word)
        {
            int RetVal = 0;

            for (int i = 0; i < Letters.Length; i++)
            {
                if ((Letters[i] != null) && (Letters[i].Length > 0))
                {
                    int Pos = Word.IndexOf(Letters[i]);
                    if (Pos != -1)
                    {
                        Word = Utils.RemoveLetterAt(Word, Pos);
                        RetVal++;
                    }
                }

            }
            return RetVal;

        }

        /// <summary>
        /// Returns TRUE if there are enough results for this word length
        /// </summary>
        /// <param name="WordLength"></param>
        /// <param name="Results"></param>
        /// <returns></returns>
        private bool EnoughResults(int WordLength, int Results)
        {
            int MaxResults = 0;
            switch (WordLength)
            {
                case 4:
                    MaxResults = 3;
                    break;
                case 3:
                    MaxResults = 20;
                    break;
                case 2:
                    MaxResults = 5;
                    break;
                default:
                    MaxResults = 50000;
                    break;
            }

            return (Results >= MaxResults);

        }


        /// <summary>
        /// Search the database for words that contain X letters
        /// from the user's letters
        /// </summary>
        /// <param name="ContainThisManyLetters"></param>
        /// <returns></returns>
        private List<ProposedWord> SearchWords(int ContainThisManyLetters, bool NoAdditionalLetters)
        {
            List<ProposedWord> RetVal = new List<ProposedWord>();

            int ResultCount = 0;

            for (int i = 0; i < WordArray.Length; i++)
            {
                string word = WordArray[i];

                bool ValidWord = false;
                if (NoAdditionalLetters)
                    ValidWord = (word.Length == (ContainThisManyLetters));
                else
                    ValidWord = (word.Length == (ContainThisManyLetters + 1));

                int LettersContained = WordContainsThisManyLetters(word);

                //Only words that have X+1 letters
                //Only words containing X letters are returned
                //Only words that meet the criteria are candidates
                if (ValidWord && (LettersContained == ContainThisManyLetters) && (WordMeetsCriteria(word)))
                {
                    ProposedWord pWord = new ProposedWord(alphabet,word, Letters);
                    RetVal.Add(pWord);

                    ResultCount++;
                    GlobalResultCount++;

                }
            }

            RetVal.TrimExcess();
            return RetVal;

        }


        /// <summary>
        /// Reset the criteria input fields
        /// </summary>
        private void ResetCriteria()
        {
            cboCritType1.SelectedIndex = -1;
            txtCritLetter1.Text = "";
            chkCritMustBeNew1.Checked = false;

            cboCritType2.SelectedIndex = -1;
            txtCritLetter2.Text = "";
            chkCritMustBeNew2.Checked = false;

            cboCritType3.SelectedIndex = -1;
            txtCritLetter3.Text = "";
            chkCritMustBeNew3.Checked = false;

            cboCritType4.SelectedIndex = -1;
            txtCritLetter4.Text = "";
            chkCritMustBeNew4.Checked = false;

        }

        private delegate int GetComboSelectedIndexDelegate(ComboBox combo);

        private int GetComboSelectedIndex(ComboBox combo)
        {
            if (combo.InvokeRequired)
            {
                return (int)this.Invoke(new GetComboSelectedIndexDelegate(GetComboSelectedIndex), new object[] { combo });
            }
            else
            {
                return combo.SelectedIndex;
            }
        }

        /// <summary>
        /// Returns TRUE if the criteria described by the passed controls is met for this word
        /// </summary>
        /// <param name="Word"></param>
        /// <param name="CritType"></param>
        /// <param name="Crit"></param>
        /// <param name="chkNew"></param>
        /// <returns></returns>
        private bool CriteriaIsMet(string Word, ComboBox CritType, TextBox Crit, CheckBox chkNew)
        {
            bool RetVal = true;

            string CritLetter = Crit.Text;

            int LetterPos;
            string Letter = "";
            int CritTypeIndex = GetComboSelectedIndex(CritType);

            switch (CritTypeIndex)
            {
                case 0: //Οποιοδήποτε γράμμα
                    LetterPos = -1;
                    if (Word.IndexOf(CritLetter) == -1) return false;
                    break;
                case 1:	// Πρώτο γράμμα
                    LetterPos = 0;
                    Letter = Word.Substring(LetterPos, 1);
                    if (Letter != CritLetter) return false;
                    break;
                case 2:	// Τελευταίο γράμμα
                    LetterPos = Word.Length - 1;
                    Letter = Word.Substring(LetterPos, 1);
                    if (Letter != CritLetter) return false;
                    break;
                default:
                    LetterPos = CritTypeIndex - 2;
                    if (LetterPos < Word.Length - 1)
                    {
                        Letter = Word.Substring(LetterPos, 1);
                        if (Letter != CritLetter) return false;
                    }
                    else
                        return false;
                    break;
            }

            //0		Οποιοδήποτε γράμμα
            //1		Πρώτο γράμμα
            //2		Τελευταίο γράμμα
            //3		2ο γράμμα
            //4		3ο γράμμα
            //5		4ο γράμμα
            //6		5ο γράμμα
            //7		6ο γράμμα

            //έλεγξε αν είναι νέο γράμμα (αν ο χρήστης έχει επιλέξει αυτό το κριτήριο)
            if ((chkNew.Checked) && (Letter != ""))
            {
                if (Utils.CountOccurances(Word, Letter) <= Utils.CountOccurances(txtLetters.Text, Letter)) return false;
            }

            return RetVal;
        }


        /// <summary>
        /// Returns TRUE if the word meets the criteria specified by the user
        /// </summary>
        /// <param name="Word"></param>
        /// <returns></returns>
        private bool WordMeetsCriteria(string Word)
        {
            bool RetVal = true;

            if (txtCritLetter1.Text.Length > 0)
            {
                RetVal = CriteriaIsMet(Word, cboCritType1, txtCritLetter1, chkCritMustBeNew1);
                if (RetVal == false) return RetVal;
            }

            if (txtCritLetter2.Text.Length > 0)
            {
                RetVal = CriteriaIsMet(Word, cboCritType2, txtCritLetter2, chkCritMustBeNew2);
                if (RetVal == false) return RetVal;
            }

            if (txtCritLetter3.Text.Length > 0)
            {
                RetVal = CriteriaIsMet(Word, cboCritType3, txtCritLetter3, chkCritMustBeNew3);
                if (RetVal == false) return RetVal;
            }

            if (txtCritLetter4.Text.Length > 0)
            {
                RetVal = CriteriaIsMet(Word, cboCritType4, txtCritLetter4, chkCritMustBeNew4);
                if (RetVal == false) return RetVal;
            }

            return RetVal;

        }




        private void ChangeCursor(bool Wait)
        {
            if (Wait)
            {
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private delegate void InitBarDelegate(ProgressBar bar, int Min, int Max, int Val);
        private void InitBar(ProgressBar bar, int Min, int Max, int Val)
        {
            if (!bar.InvokeRequired)
            {
                bar.Minimum = Min;
                bar.Maximum = Max;
                bar.Value = Val;
            }
            else
                Invoke(new InitBarDelegate(InitBar), new object[] { bar, Min, Max, Val });
        }

        private delegate void SetBarValueDelegate(int Val);
        private void SetBarValue(int Val)
        {
            if (!progress1.InvokeRequired)
            {
                progress1.Value = Val;
            }
            else
                Invoke(new SetBarValueDelegate(SetBarValue), new object[] { Val });

        }

        private delegate void SetStatusTextDelegate(string Text);
        private void SetStatusText(string Text)
        {
            if (!statusBar1.InvokeRequired)
            {
                statusBar1.Panels[0].Text = Text;
            }
            else
                Invoke(new SetStatusTextDelegate(SetStatusText), new object[] { Text });
        }

        /// <summary>
        /// Find words that contain the letters that the user specified
        /// </summary>
        private void FindWords()
        {

            Working = true;
            Letters = this.GetLetters();
            int LetterCount = GetLetterCount();
            //Find words that contain the letters that the user specified.
            GlobalResults = new List<ProposedWord>();
            GlobalResultCount = 0;

            InitBar(progress1, 0, LetterCount - 2, 0);

            SetStatusText(Utils.RM("SearchingForWords"));

            int Step = 0;
            for (int i = LetterCount; i >= 2; i--)
            {
                GlobalResults.AddRange(SearchWords(i, chkNoAdditional.Checked));
                SetBarValue(Step);
                Step++;
            }

            SetStatusText(Utils.RM("RenderingWords"));

            SortResults(ref GlobalResults, ProposedWord.SortType.Length);

            WorkFinished();

            SetBarValue(progress1.Minimum);

            SetStatusText(string.Format("{0} {1}", GlobalResultCount,Utils.RM("Words")));

        }

        private delegate void WorkFinishedDelegate();

        /// <summary>
        /// Called when the search has finished
        /// </summary>
        private void WorkFinished()
        {
            if (webBrowser1.InvokeRequired)
            {
                Invoke(new WorkFinishedDelegate(WorkFinished), new object[] { });
            }
            else
            {
                ShowResults(GlobalResults);

                Letters = new string[7];
                Working = false;
                chkNoAdditional.Checked = false;

                ChangeCursor(false);

                this.cmdSearch.Enabled = true;
                this.cmdCancel.Enabled = false;

                SetBarValue(0);
            }

        }

        private void SortResults(ref List<ProposedWord> Results, ProposedWord.SortType sortType)
        {
            if (Results == null) return;
            Results.Sort(new ProposedWord.Comparer(sortType));
        }


        /// <summary>
        /// Returns an array of strings that contains the individual letters typed in
        /// </summary>
        /// <returns></returns>
        private string[] GetLetters()
        {
            string[] RetVal = new string[this.txtLetters.Text.Length];
            for (int i = 0; i < txtLetters.Text.Length; i++)
                RetVal[i] = txtLetters.Text.Substring(i, 1);
            return RetVal;

        }

        private void Form2_Load(object sender, System.EventArgs e)
        {

            ReadWords();
            ResetCriteria();
        }

        /// <summary>
        /// Reads the words from tha database (text file) and saves them in
        /// the array WordList
        /// </summary>
        private void ReadWords()
        {

            try
            {
                StreamReader sr = new StreamReader(Settings.Default.WordsFile, System.Text.Encoding.UTF8);
                string Data = sr.ReadToEnd();
                Data = Data.Replace("\r\n", "\r");
                WordArray = Data.Split(new char[] { '\r' });
                sr.Close();
                sr = null;

                StringBuilder sb = new StringBuilder();
                //Remove words with 2 letters
                for (int i = 0; i < WordArray.Length; i++)
                {
                    //ignore 2 letter words
                    if (WordArray[i].Length > 2)
                    {
                        if (sb.Length > 0) sb.Append("\r");
                        sb.Append(WordArray[i]);
                    }
                }

                WordArray = sb.ToString().Split(new char[] { '\r' });

            }
            catch (Exception ex)
            {
                WordArray = new string[0];

                MessageBox.Show(Utils.RM("WordsFileMissing") + "\r\n\r\n" + ex.Message, Utils.RM("WordsFileNotFound"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cmdSearch_Click(object sender, System.EventArgs e)
        {

            if (txtLetters.Text.Length < 2) return;

            this.cmdSearch.Enabled = false;
            this.cmdCancel.Enabled = true;

            txtLetters.Text = txtLetters.Text.ToUpper();

            //Start worker thread to do the job

            ChangeCursor(true);

            if (System.Diagnostics.Debugger.IsAttached)
                FindWords();
            else
            {
                worker = new Thread(new ThreadStart(FindWords));
                worker.IsBackground = true;
                worker.Priority = ThreadPriority.AboveNormal;
                worker.Start();
            }

        }


        private void txtLetters_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //If a non-greek letter characker was pressed,ignore it
            if (!(((e.KeyChar >= alphabet.FirstLetter) && (e.KeyChar <= alphabet.LastLetter)) || ((e.KeyChar >= alphabet.FirstLowerLetter) && (e.KeyChar <= alphabet.LastLowerLetter)) || (e.KeyChar == 8)))
            {
                //SetStatusText(Utils.RM("InvalidLetter" ) );
                e.Handled = true;
            }

        }


        private void lblSortOnWord_Click(object sender, System.EventArgs e)
        {
            if (Working) return;
            ChangeCursor(true);
            SortResults(ref GlobalResults, ProposedWord.SortType.Word);
            ShowResults(GlobalResults);
            ChangeCursor(false);
        }

        private void lblSortOnLength_Click(object sender, System.EventArgs e)
        {
            if (Working) return;
            ChangeCursor(true);
            SortResults(ref GlobalResults, ProposedWord.SortType.Length);
            ShowResults(GlobalResults);
            ChangeCursor(false);

        }

        private void lblSortOnNewLetters_Click(object sender, System.EventArgs e)
        {
            if (Working) return;
            ChangeCursor(true);
            SortResults(ref GlobalResults, ProposedWord.SortType.NewLetters);
            ShowResults(GlobalResults);
            ChangeCursor(false);

        }


        private void lblSortOnWordInversed_Click(object sender, System.EventArgs e)
        {
            if (Working) return;

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            SortResults(ref GlobalResults, ProposedWord.SortType.WordInverse);
            ShowResults(GlobalResults);
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            if (worker != null)
            {
                worker.Abort();
                worker.Join();
            }
            WorkFinished();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {

        }

        private void btnClear_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            ResetCriteria();
        }

        private void lblSortOnValue_Click(object sender, System.EventArgs e)
        {
            if (Working) return;

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            SortResults(ref GlobalResults, ProposedWord.SortType.Value);
            ShowResults(GlobalResults);
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void SortOnPosition(object sender, System.EventArgs e)
        {
            if (Working) return;

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            SortResults(ref GlobalResults, ProposedWord.SortType.NewLetterLocation);
            ShowResults(GlobalResults);
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }



        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            //Remove word from WordArray
            System.Collections.ArrayList NewWords = new System.Collections.ArrayList(this.WordArray);
            NewWords.Remove(rightClick.Word);
            WordArray = (string[])NewWords.ToArray(typeof(string));

            //Remove word from global results
            for (int i = 0; i < GlobalResults.Count; i++)
            {
                if (GlobalResults[i].Word == rightClick.Word)
                {
                    GlobalResults.RemoveAt(i);
                    break;
                }
            }

            ////Show results so that removed word is removed from text box
            //ShowResults(GlobalResults);

            WordsModified = true;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //read words and load alphabet
            ReadWords();
            alphabet = new Alphabet();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            Utils.MakeTopMost(this, false);
            settings.ShowDialog(this);
            Utils.MakeTopMost(this, Settings.Default.TopMost);

            try
            {
                this.Controls.Clear();
                InitializeComponent();
                
                //read words and load alphabet
                ReadWords();
                alphabet = new Alphabet();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Utils.RM("Error"), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuShowWords_Click(object sender, EventArgs e)
        {

            if ((Settings.Default.WordsFile.Length > 0) && (System.IO.File.Exists(Settings.Default.WordsFile)))
            {
                try
                {
                    MessageBox.Show( Utils.RM("EditInstructions") );
                    System.Diagnostics.Process pr = System.Diagnostics.Process.Start(Settings.Default.WordsFile);
                    pr.WaitForExit();

                    //Read words again as the language might have changed
                    ReadWords();

                    //Load the alphabet again
                    alphabet = new Alphabet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( Utils.RM("Error") , ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("el");
            InitializeComponent();
        }

        private void frmScrabbleHelper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                if (WordsModified)
                {
                    if (MessageBox.Show(Utils.RM("ChangesMade"), Utils.RM("Save"), MessageBoxButtons.YesNo) == DialogResult.No) return;
                    try
                    {
                        File.WriteAllLines(Settings.Default.WordsFile, WordArray, Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Utils.RM("ErrorWhileSaving") + ex.Message);
                    }
                }
            }

        }

        private bool rtbIsFront = true;
        private void button1_Click_1(object sender, EventArgs e)
        {
            rtbIsFront = !rtbIsFront;
            if (rtbIsFront)
            {
                rtbText.BringToFront();
                this.webBrowser1.SendToBack();
            }
            else
            {
                webBrowser1.BringToFront();
                rtbText.SendToBack();

            }
        }

        private void rtbText_MouseDown(object sender, MouseEventArgs e)
        {
            if (Working) return;

            if (e.Button == MouseButtons.Right)
            {
                rightClick.CharIndex = rtbText.GetCharIndexFromPosition(e.Location);
                rightClick.LineIndex = rtbText.GetLineFromCharIndex(rightClick.CharIndex);
                if (rightClick.LineIndex < rtbText.Lines.Length - 1)
                {
                    rtbText.SelectionStart = rightClick.CharIndex;
                    rightClick.Word = rtbText.Lines[rightClick.LineIndex];
                    rightClick.Word = rightClick.Word.Split(" ".ToCharArray())[0];

                    this.DeleteMenuItem.Text = Utils.RM("Delete") + ": " + rightClick.Word;

                    ResultsMenu.Show(rtbText, e.Location);
                }
            }
        }


    }
}
