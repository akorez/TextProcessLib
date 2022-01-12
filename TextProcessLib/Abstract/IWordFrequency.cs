using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessLib.Abstract
{
    public interface IWordFrequency
    {
        string Word { get; }

        int Frequency { get; }
    }
}
