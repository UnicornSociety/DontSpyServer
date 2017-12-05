using System.Collections.Generic;

namespace ModernEncryption.Interfaces
{
    public interface IKeyHandling
    {
        string ProduceKeys(int n);
        Dictionary<int, int> CreateKey(int n);
        Dictionary<int, int> KeyTable(string key);
    }
}
