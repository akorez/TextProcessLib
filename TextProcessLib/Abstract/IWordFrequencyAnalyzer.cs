using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessLib.Abstract
{
    public interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);

        int CalculateFrequencyForWord(string text, string word);

        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
