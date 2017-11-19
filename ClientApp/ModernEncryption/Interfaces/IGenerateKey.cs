using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption.Interfaces
{
    interface IGenerateKey
    {
        string ProduceKeys(int n);
        Dictionary<int, int> CreateKey(int n, String channelId);
    }
}
