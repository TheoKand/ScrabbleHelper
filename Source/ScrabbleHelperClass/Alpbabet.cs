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
                    _letterValues['Á'] = 1;
                    _letterValues['Â'] = 8;
                    _letterValues['Ã'] = 4;
                    _letterValues['Ä'] = 4;
                    _letterValues['Å'] = 1;
                    _letterValues['Æ'] = 10;
                    _letterValues['Ç'] = 1;
                    _letterValues['È'] = 10;
                    _letterValues['É'] = 1;
                    _letterValues['Ê'] = 2;
                    _letterValues['Ë'] = 2;
                    _letterValues['Ì'] = 2;
                    _letterValues['Í'] = 1;
                    _letterValues['Î'] = 10;
                    _letterValues['Ï'] = 1;
                    _letterValues['Ð'] = 2;
                    _letterValues['Ñ'] = 2;
                    _letterValues['Ó'] = 1;
                    _letterValues['Ô'] = 1;
                    _letterValues['Õ'] = 2;
                    _letterValues['Ö'] = 8;
                    _letterValues['×'] = 10;
                    _letterValues['Ø'] = 10;
                    _letterValues['Ù'] = 4;
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
