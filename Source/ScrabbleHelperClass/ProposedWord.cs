using ScrabbleHelper2.Properties;
using System;
using System.Text;
using System.Collections.Generic;

namespace ScrabbleHelper2
{
	/// <summary>
	/// Summary description for ProposedWord.
	/// </summary>
	public sealed class ProposedWord
	{

		public sealed class Comparer : IComparer<ProposedWord>
		{
			#region IComparer Members

			private SortType _sortType;

			public Comparer(SortType sortType) 
			{
				_sortType = sortType;
			}

            public int Compare(ProposedWord x, ProposedWord y)
			{
				int SortResult=0;

				if (_sortType == SortType.Word) 
				{
					SortResult = x.Word[0].CompareTo(y.Word[0]);
					if (SortResult==0) SortResult = y.Length.CompareTo(x.Length);
					if (SortResult==0) SortResult = y.Value.CompareTo(x.Value);
				}
				else if (_sortType == SortType.Length )
				{
					SortResult = y.Length.CompareTo(x.Length);
					if (SortResult==0) SortResult = y.Value.CompareTo(x.Value);
					if (SortResult==0) SortResult = string.Concat(x.NewLetters.ToArray()).CompareTo( string.Concat(y.NewLetters.ToArray()) );
				}
				else if (_sortType==SortType.WordInverse) 
				{
					SortResult = x.Word[x.Word.Length-1].CompareTo(y.Word[y.Word.Length-1]);
					if (SortResult==0) SortResult = y.Length.CompareTo(x.Length);
					if (SortResult==0) SortResult = y.Value.CompareTo(x.Value);
				}
				else if (_sortType==SortType.NewLetters)
				{
					SortResult = string.Concat(x.NewLetters.ToArray()).CompareTo( string.Concat(y.NewLetters.ToArray()) );
					if (SortResult==0) SortResult = y.Length.CompareTo(x.Length);
					if (SortResult==0) SortResult = y.Value.CompareTo(x.Value);
				}
				else if (_sortType==SortType.Value)
				{
					SortResult = y.Value.CompareTo(x.Value);
					if (SortResult==0) SortResult = y.Length.CompareTo(x.Length);
					if (SortResult==0) SortResult = string.Concat(x.NewLetters.ToArray()).CompareTo( string.Concat(y.NewLetters.ToArray()) );

				} 
				else if (_sortType ==SortType.NewLetterLocation) 
				{
					SortResult = x.NewLetterLocation.CompareTo(  y.NewLetterLocation );
					if (SortResult==0) SortResult = string.Concat(x.NewLetters.ToArray()).CompareTo( string.Concat(y.NewLetters.ToArray()) );
					if (SortResult==0) SortResult = x.Word[0].CompareTo(y.Word[0]);
					if (SortResult==0) SortResult = y.Length.CompareTo(x.Length);
					if (SortResult==0) SortResult = y.Value.CompareTo(x.Value);

				}

				return SortResult;
			}
			

			#endregion
		}


		public enum SortType 
		{
			Word,
			WordInverse,
			NewLetters,
			Length,
			Value,
			NewLetterLocation
		}

		private string _word;
		private List<string> _newLetters;
		private int _length;
		private int _value;
		private int _newLetterLocation=-1;

		/// <summary>
		/// The proposed word
		/// </summary>
		public string Word 
		{
			get { return _word; }
			set { _word = value; }
		}

		/// <summary>
		/// The value of the word
		/// </summary>
		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}

		/// <summary>
		/// The location of the new letter
		/// </summary>
		public int NewLetterLocation
		{
			get { 
				return _newLetterLocation; 
			}
			set { _newLetterLocation = value; }
		}

		/// <summary>
		/// The location of the new letter
		/// </summary>
		public string NewLetterLocationDesc
		{
			get 
			{ 
				if (_newLetterLocation==-1)
					return "";
				else
					return (_newLetterLocation+1).ToString();
			}

		}

		/// <summary>
		/// The letters of the word that are the user does not
		/// currently have
		/// </summary>
		public List<string> NewLetters 
		{
			get { return _newLetters; }
			set { _newLetters = value; }
		}

		public int Length 
		{
			get { return _length; }
		}

		/// <summary>
		/// Constructor of ProposedWord. The word and the user's existing letters
		/// are passed.
		/// </summary>
		/// <param name="word"></param>
		/// <param name="ExistingLetters"></param>
		public ProposedWord(Alphabet alphabet,string word, string[] ExistingLettersArray)
		{
			_word = word;
			_length = _word.Length;

			string ExistingLetters = string.Concat( ExistingLettersArray );

			//Remove existing letters from proposed word, to find out new letters
			_newLetters = new List<string>(1);
			for(int i=0 ; i <ExistingLetters.Length ; i++) 
			{
				int Pos = word.IndexOf( ExistingLetters.Substring(i,1));
				if (Pos!=-1) 
					word = Utils.RemoveLetterAt( word, Pos );
			}

			//if there are new letters
			if (word.Length>0) 
			{

				_newLetters.Add( word.Substring(0,1));
				_newLetterLocation = _word.IndexOf( (string)(_newLetters[0]) );

			}

			_value = Utils.GetWordValue(alphabet,_word);
									 
		}

	}
}
