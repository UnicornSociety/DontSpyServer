using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption.Interfaces
{
    public interface IGenerateKey
    {
        string ProduceKeys(int n);
        Dictionary<int, int> CreateKey(int n);
        Dictionary<int, int> KeyTable(string key);
    }
}
