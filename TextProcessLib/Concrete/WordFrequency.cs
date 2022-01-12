using System;
using System.Collections.Generic;
using System.Text;
using TextProcessLib.Abstract;

namespace TextProcessLib.Concrete
{
    public class WordFrequency : IWordFrequency
    {
        public WordFrequency(string word, int frequency)
        {
            Word = word;
            Frequency = frequency;
        }

        public string Word { get; }

        public int Frequency { get; }

        public override bool Equals (object obj)
        {
            var temp = (WordFrequency)obj;
            return this.Frequency == temp.Frequency && this.Word.ToLower() == temp.Word.ToLower();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
