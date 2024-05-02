[![.NET](https://github.com/akorez/TextProcessLib/actions/workflows/tests.yml/badge.svg)](https://github.com/akorez/TextProcessLib/actions/workflows/tests.yml) 
# TextProcessLib
This repo contains a sample library code and test methods that calculate the frequency of the words in the given text on a word-by-word basis.

The library contains 3 methods. These:

- CalculateHighestFrequency return the highest frequency in the text (several words might actually have this frequency) 
- CalculateFrequencyForWord return the frequency of the specified word 
- CalculateMostFrequentNWords return a list of the most frequent „n‟ words in the input text, all the words returned in lower case. If several words have the same frequency, this method should return them in ascendant alphabetical order (for input text “The sun shines over the lake” and n = 3, it should return the list { (“the”, 2), (“lake”, 1), (“over”, 1) } 


The test scenarios of these 3 methods are also included under the Test project.

[Test Coverage](https://github.com/akorez/TextProcessLib/actions/runs/8914373902)






