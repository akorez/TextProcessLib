using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextProcessLib.Abstract;

namespace TextProcessLib.Concrete
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        /// <summary>
        /// Calculates how many times the most repeated word is repeated in a text. 
        /// Returns 0 if no text is given (empty or null)
        /// </summary>
        /// <param name="text">Sample text</param>
        /// <returns>Returns the number of repeatitions of the most repeated word as an integer</returns>
        public int CalculateHighestFrequency(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            var result = TextProcess(text)
                .Select(x => new { Word = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            if (result != null)
            {
                return result.Count;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// Calculates the result of how many times a given word occurs in a text.
        /// Returns 0 if a text or search word is not given (empty or null).
        /// </summary>
        /// <param name="text">Sample text</param>
        /// <param name="word">Sample word</param>
        /// <returns>Returns the number of occurrences if the given word is present in the sample text, and 0 if not.</returns>
        public int CalculateFrequencyForWord(string text, string word)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(word))
            {
                return 0;
            }
         
            var result = TextProcess(text)
                   .Select(x => new { Word = x.Key, Count = x.Count() })
                   .OrderByDescending(x => x.Count)
                   .Where(x => x.Word.Equals(word))
                   .FirstOrDefault();

            if (result != null)
            {
                return result.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Calculates a list of the most frequent 'n' words in the input te
        /// </summary>
        /// <param name="text">Sample Text</param>
        /// <param name="n">Number of Most Frequent Words</param>
        /// <returns>Returns an empty list if the given text is empty/null, or the desired word count is 0. 
        ///          Otherwise, all the words in the list returned in lower case.</returns>
        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            if (string.IsNullOrEmpty(text) || n == 0)
            {
                return Array.Empty<IWordFrequency>(); // or return Null
            }

            var result = TextProcess(text)
                       .Select(x => new WordFrequency(x.Key.ToLower(), x.Count()))
                       .OrderByDescending(x => x.Frequency)
                       .ThenBy(x => x.Word)
                       .Take(n);


            if (result != null)
            {
                return result.ToList<IWordFrequency>(); 
            }
            else
            {
                return Array.Empty<IWordFrequency>(); // or return Null
            }

        }

        /// <summary>
        /// It is a common method. Used in 3 methods and used for text processing.
        /// </summary>
        /// <param name="text">Sample Text</param>
        /// <returns>Processed Text</returns>
        private static IEnumerable<IGrouping<string, string>> TextProcess(string text)
        {
            return string.Concat(text.Select(x => ((x < 65 || x > 90) && (x < 97 || x > 122) && x != 32) ? ' ' : x)) // Only a-z or A-Z characters are taken into account
                            .Split(' ')
                            .Where(x => !String.IsNullOrWhiteSpace(x))
                            .GroupBy(x => x, StringComparer.InvariantCultureIgnoreCase);
        }

    }
}
