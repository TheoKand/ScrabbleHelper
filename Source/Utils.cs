using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Resources;
using System.Threading;
using ScrabbleHelper2.Properties;
using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

namespace ScrabbleHelper2
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public sealed class Utils
	{

        private static ResourceManager rm;


        /// <summary>
        /// Returns a localized resource
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RM(string key)
        {

            string ResourceFileName = "ScrabbleHelper2.Properties.Resources";
            if (rm == null) rm = new ResourceManager(ResourceFileName, typeof(Utils).Assembly);
            key = key + "_" + Thread.CurrentThread.CurrentUICulture.Name;
            rm.IgnoreCase = true;

            string RetVal="";
            try
            {
                RetVal= rm.GetString(key);
            }
            catch (System.Resources.MissingManifestResourceException ex)
            {
                MessageBox.Show(Utils.RM("Error"), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return RetVal;

        }

        public static void MakeTopMost(System.Windows.Forms.Form f, bool Yes)
        {
            if ((Yes) && (!System.Diagnostics.Debugger.IsAttached))
            {
                f.TopMost = true;
            }
            else
            {
                f.TopMost = false;
            }

        }

        /// <summary>
        /// Returns the words file depending on the current language
        /// </summary>
        /// <returns></returns>
        public static string GetWordsFile()
        {
            return Application.StartupPath + @"\Words-" + Settings.Default.Language + ".txt";
        }

		/// <summary>
		/// Removes the letter at the specified index (zero based) and
		/// returns the word
		/// </summary>
		/// <param name="Word"></param>
		/// <param name="Index"></param>
		/// <returns></returns>
		public static string RemoveLetterAt(string Word,int Index) 
		{
			string RetVal = Word.Substring(0,Index);
			RetVal = RetVal + Word.Substring(Index+1);
			return RetVal;

		}

		public static string InverseString(string word) 
		{
			StringBuilder sb = new StringBuilder(word.Length);
			for(int i=0; i <word.Length ; i++) 
				sb.Append(word.Substring(word.Length -(i+1),1));
			return sb.ToString();

		}


		public static int CountOccurances(string word,string letter) 
		{
			int RetVal=0;
			int StartPos =0;
			int MatchPos = word.IndexOf(letter,StartPos);
			while(MatchPos!=-1) 
			{
				RetVal++;
				if (MatchPos==(word.Length-1)) break;
				StartPos=MatchPos+1;
				MatchPos = word.IndexOf(letter,StartPos);
			}

			return RetVal;

		}
 
		public static int GetWordValue(Alphabet alphabet,string Word) 
		{
			int Retval=0;
			for(int i=0 ; i<Word.Length ; i++) 
			{
                Retval = Retval + alphabet.GetLetterValue(Word[i]);
			}

			return Retval;
		}

        public static string HTMLToRTF(string Html)
        {

            string RtfHeader = @"{\rtf1\ansi\ansicpg1253\deff0\deflang1032{\fonttbl{\f0\fnil\fcharset161{\*\fname Courier New;}Courier New;}{\f1\fnil\fcharset0 Courier New;}}{\colortbl ;\red255\green0\blue0;}\viewkind4\uc1\pard\f0\fs25";
            string RtfFooter = "";

            System.Text.StringBuilder StringBuilder = new System.Text.StringBuilder(Html);
            StringBuilder.Replace("<b>", @"\b ");
            StringBuilder.Replace("</b>", @"\b0 ");
            StringBuilder.Replace("<i>", @"\i ");
            StringBuilder.Replace("</i>", @"\i0 ");
            StringBuilder.Replace("<u>", @"\ul ");
            StringBuilder.Replace("</u>", @"\ulnone ");
            StringBuilder.Replace("<B>", @"\b ");
            StringBuilder.Replace("</B>", @"\b0 ");
            StringBuilder.Replace("<I>", @"\i ");
            StringBuilder.Replace("</I>", @"\i0 ");
            StringBuilder.Replace("<U>", @"\ul ");
            StringBuilder.Replace("</U>", @"\ulnone ");
            StringBuilder.Replace("<strong>", @"\b ");
            StringBuilder.Replace("</strong>", @"\b0 ");
            StringBuilder.Replace("<em>", @"\i ");
            StringBuilder.Replace("</em>", @"\i0 ");
            StringBuilder.Replace("<STRONG>", @"\b ");
            StringBuilder.Replace("</STRONG>", @"\b0 ");
            StringBuilder.Replace("<EM>", @"\i ");
            StringBuilder.Replace("</EM>", @"\i0 ");
            StringBuilder.Replace("<Strong>", @"\b ");
            StringBuilder.Replace("</Strong>", @"\b0 ");
            StringBuilder.Replace("<Em>", @"\i ");
            StringBuilder.Replace("</Em>", @"\i0 ");
            StringBuilder.Replace("<br>", @"\line ");
            StringBuilder.Replace("<BR>", @"\line ");
            StringBuilder.Replace("<Br>", @"\line ");
            StringBuilder.Replace("<br/>", @"\line ");
            StringBuilder.Replace("<BR/>", @"\line ");
            StringBuilder.Replace("<Br/>", @"\line ");
            StringBuilder.Replace("<p>", "");
            StringBuilder.Replace("<P>", "");
            StringBuilder.Replace("</p>", @"\par ");
            StringBuilder.Replace("</P>", @"\par ");
            StringBuilder.Replace("Á", @"\'c1");
            StringBuilder.Replace("Â", @"\'c2");
            StringBuilder.Replace("Ã", @"\'c3");
            StringBuilder.Replace("Ä", @"\'c4");
            StringBuilder.Replace("Å", @"\'c5");
            StringBuilder.Replace("Æ", @"\'c6");
            StringBuilder.Replace("Ç", @"\'c7");
            StringBuilder.Replace("È", @"\'c8");
            StringBuilder.Replace("É", @"\'c9");
            StringBuilder.Replace("Ê", @"\'ca");
            StringBuilder.Replace("Ë", @"\'cb");
            StringBuilder.Replace("Ì", @"\'cc");
            StringBuilder.Replace("Í", @"\'cd");
            StringBuilder.Replace("Î", @"\'ce");
            StringBuilder.Replace("Ï", @"\'cf");
            StringBuilder.Replace("Ð", @"\'d0");
            StringBuilder.Replace("Ñ", @"\'d1");
            StringBuilder.Replace("Ó", @"\'d3");
            StringBuilder.Replace("Ô", @"\'d4");
            StringBuilder.Replace("Õ", @"\'d5");
            StringBuilder.Replace("Ö", @"\'d6");
            StringBuilder.Replace("×", @"\'d7");
            StringBuilder.Replace("Ø", @"\'d8");
            StringBuilder.Replace("Ù", @"\'d9");
            StringBuilder.Replace("á", @"\'e1");
            StringBuilder.Replace("â", @"\'e2");
            StringBuilder.Replace("ã", @"\'e3");
            StringBuilder.Replace("ä", @"\'e4");
            StringBuilder.Replace("å", @"\'e5");
            StringBuilder.Replace("æ", @"\'e6");
            StringBuilder.Replace("ç", @"\'e7");
            StringBuilder.Replace("è", @"\'e8");
            StringBuilder.Replace("é", @"\'e9");
            StringBuilder.Replace("ê", @"\'ea");
            StringBuilder.Replace("ë", @"\'eb");
            StringBuilder.Replace("ì", @"\'ec");
            StringBuilder.Replace("í", @"\'ed");
            StringBuilder.Replace("î", @"\'ee");
            StringBuilder.Replace("ï", @"\'ef");
            StringBuilder.Replace("ð", @"\'f0");
            StringBuilder.Replace("ñ", @"\'f1");
            StringBuilder.Replace("ó", @"\'f3");
            StringBuilder.Replace("ô", @"\'f4");
            StringBuilder.Replace("õ", @"\'f5");
            StringBuilder.Replace("ö", @"\'f6");
            StringBuilder.Replace("÷", @"\'f7");
            StringBuilder.Replace("ø", @"\'f8");
            StringBuilder.Replace("ù", @"\'f9");
            StringBuilder.Replace("ò", @"\'f2");
            StringBuilder.Replace("Ü", @"\'dc");
            StringBuilder.Replace("Ý", @"\'dd");
            StringBuilder.Replace("ß", @"\'df");
            StringBuilder.Replace("ý", @"\'fd");
            StringBuilder.Replace("Þ", @"\'de");
            StringBuilder.Replace("ü", @"\'fc");
            StringBuilder.Replace("þ", @"\'fe");
            StringBuilder.Replace("ú", @"\'fa");
            StringBuilder.Replace("û", @"\'fb");
            StringBuilder.Replace("&nbsp;", " ");

            StringBuilder.Replace("<startcolor>", @"\cf1 ");
            StringBuilder.Replace("<endcolor>", @"\cf0 ");

            StringBuilder.Insert(0, RtfHeader);
            StringBuilder.Append(RtfFooter);
            return StringBuilder.ToString();


        }


	}
}
