using System.Threading;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrabbleHelper2
{
    public sealed class Alphabet
    {
        private char[] _letters;
        private string _alphabet;
        private static Dictionary<char, int> _letterValues;

        public Alphabet()
        {
            _alphabet = Utils.RM("Alphabet");
            _letters = _alphabet.ToCharArray();

            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "el":
                    _letterValues = new Dictionary<char, int>(23);
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 8;
                    _letterValues['�'] = 4;
                    _letterValues['�'] = 4;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 10;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 10;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 2;
                    _letterValues['�'] = 2;
                    _letterValues['�'] = 2;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 10;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 2;
                    _letterValues['�'] = 2;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 1;
                    _letterValues['�'] = 2;
                    _letterValues['�'] = 8;
                    _letterValues['�'] = 10;
                    _letterValues['�'] = 10;
                    _letterValues['�'] = 4;
                    break;

                case "en":

                    _letterValues = new Dictionary<char, int>(24);
                    _letterValues['A'] = 1;
                    _letterValues['B'] = 8;
                    _letterValues['C'] = 4;
                    _letterValues['D'] = 4;
                    _letterValues['E'] = 1;
                    _letterValues['F'] = 10;
                    _letterValues['G'] = 1;
                    _letterValues['H'] = 10;
                    _letterValues['I'] = 1;
                    _letterValues['J'] = 2;
                    _letterValues['K'] = 2;
                    _letterValues['L'] = 2;
                    _letterValues['M'] = 1;
                    _letterValues['N'] = 10;
                    _letterValues['O'] = 1;
                    _letterValues['P'] = 2;
                    _letterValues['Q'] = 2;
                    _letterValues['R'] = 1;
                    _letterValues['S'] = 1;
                    _letterValues['T'] = 2;
                    _letterValues['U'] = 8;
                    _letterValues['V'] = 10;
                    _letterValues['X'] = 10;
                    _letterValues['Y'] = 4;
                    _letterValues['Z'] = 4;
                    break;
            }

        }
                                               
        public int GetLetterValue(char Letter)
        {
            int RetVal = 1;
            try
            {
                RetVal = (int)_letterValues[Letter];
            }
            catch { }

            return RetVal;

        }

        public char FirstLetter
        {
            get
            {
                return _alphabet[0];
            }
        }

        public char LastLetter
        {
            get
            {
                return _alphabet[_alphabet.Length-1 ];
            }
        }

        public char FirstLowerLetter
        {
            get
            {
                return _alphabet.ToLower()[0];
            }
        }

        public char LastLowerLetter
        {
            get
            {
                return _alphabet.ToLower()[_alphabet.Length - 1];
            }
        }

        public bool LetterIsInAlphabet(string letter)
        {
            return (_alphabet.IndexOf(letter.ToUpper()) != -1);
        }

        public bool LetterIsInAlphabet(char letter)
        {
            return (Array.IndexOf(_letters,letter )!= -1);
        }

    }
}
