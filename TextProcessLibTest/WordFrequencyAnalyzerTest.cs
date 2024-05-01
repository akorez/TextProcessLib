using System.Collections.Generic;
using TextProcessLib.Abstract;
using TextProcessLib.Concrete;
using System.Linq;
using Xunit;

namespace TextProcessingLibraryTest
{
    public class WordFrequencyAnalyzerTest
    {
        private readonly WordFrequencyAnalyzer _wordFrequencyAnalyzer;

        public WordFrequencyAnalyzerTest()
        {
            _wordFrequencyAnalyzer = new WordFrequencyAnalyzer();
        }

        #region Tests of CalculateHighestFrequency Method
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void InputTextValueNullorEmpty_CalculateHighestFrequency_ReturnZeroValue(string text)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            Assert.Equal(0, actualResult);
        }

        [Theory]
        [InlineData("I am from Turkey,I'm a C# .Net Developer. I like playing basketball!")]
        public void InputTextValueNotNullorEmpty_CalculateHighestFrequency_ReturnIntegerValue(string text)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            Assert.Equal(3, actualResult); // Threee times "I" word 
        }

        [Theory]
        [InlineData("?!!!=0  @--***    ..,")]
        public void InputTextValueNotLetter_CalculateHighestFrequency_ReturnZeroValue(string text)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            Assert.Equal(0, actualResult);
        }
        #endregion


        #region Tests of CalculateFrequencyForWord Method
        [Theory]
        [InlineData("","sun")]
        [InlineData(null,"sun")]
        public void InputTextValueNullorEmpty_CalculateFrequencyForWord_ReturnZeroValue(string text,string word)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text,word);

            Assert.Equal(0, actualResult);
        }

        [Theory]
        [InlineData("I love the Unit Test", "")]
        [InlineData("I love the Unit Test", null)]
        public void InputWordValueNullorEmpty_CalculateFrequencyForWord_ReturnZeroValue(string text, string word)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            Assert.Equal(0, actualResult);
        }

        [Theory]
        [InlineData("I am from Turkey,I'm a C# .Net Developer. I like playing basketball!", "I")]
        public void InputTextValueAndWordValueNotNullorEmpty_CalculateFrequencyForWord_ReturnIntegerValue(string text,string word)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            Assert.Equal(3, actualResult); // Threee times "I" word 
        }

        [Theory]
        [InlineData("I am from Turkey,I'm a C# .Net Developer. I like playing basketball!", "football")]
        public void InputTextValueAndWordValueNotNullorEmpty_ButWordNotInValueText_CalculateFrequencyForWord_ReturnZeroValue(string text, string word)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            Assert.Equal(0, actualResult); 
        }

        [Theory]
        [InlineData("?!!!=0  @--***    ..,","Netherlands")]
        public void InputTextValueNotLetter_CalculateFrequencyForWord_ReturnZeroValue(string text,string word)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            Assert.Equal(0, actualResult);
        }
        #endregion


        #region Tests of CalculateMostFrequentNWords Method
        [Theory]
        [InlineData("", 3)]
        [InlineData(null, 3)]
        public void InputTextValueNullorEmpty_CalculateMostFrequentNWords_ReturnEmpty(string text, int n)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, n);

            Assert.Empty(actualResult);
        }


        [Theory]
        [InlineData("The sun shines over the lake", 0)]        
        public void InputNValueEqualsZero_CalculateMostFrequentNWords_ReturnEmpty(string text, int n)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, n);

            Assert.Empty(actualResult);
        }

        [Theory]
        [InlineData("The sun shines over the lake", 3)]
        public void InputTextValueNotNullOrEmptyAndNCountNotZero_CalculateMostFrequentNWords_ReturnArray(string text, int n)
        {
            IList<IWordFrequency> expectedResult = new List<IWordFrequency> { new WordFrequency("the", 2),
                                                                              new WordFrequency("lake", 1),
                                                                              new WordFrequency("over", 1)
                                                                            };


            var actualResult = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, n);

            Assert.True(actualResult.SequenceEqual(expectedResult));

        }

        [Theory]
        [InlineData("?!!!=0  @--***    ..,", 2)]
        public void InputTextValueNotLetter_CalculateMostFrequentNWords_ReturnZeroValue(string text, int n)
        {
            var actualResult = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, n);

            Assert.Empty(actualResult);
        }

        #endregion
    }
}
