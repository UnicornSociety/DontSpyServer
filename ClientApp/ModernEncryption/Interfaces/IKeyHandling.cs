using System.Collections.Generic;

namespace ModernEncryption.Interfaces
{
    public interface IKeyHandling
    {
        int[] ProduceKeys(int n);
        Dictionary<int, int> CreateKey(int n);
        Dictionary<int, int> KeyTable(int[] key);
    }
}
