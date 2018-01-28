using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class DecryptionLogic : IDecrypt
    {
        private readonly char[] _messageTextSymbols;
        private readonly Message _message;
        private readonly Dictionary<int, int> _keyTable;

        public DecryptionLogic(Message message, Dictionary<int, int> keyTable)
        {
            _message = message;
            _messageTextSymbols = message.Text.ToCharArray();
            _keyTable = keyTable;
        }

        public DecryptedMessage Decrypt()
        {
            var concatenatedDecryptedSymbols = string.Empty;

            for (var i = 0; i < _messageTextSymbols.Length; i++)
            {
                var permutedChipher = RevertCharacterPair(_messageTextSymbols[i], _messageTextSymbols[++i]);
                var chiper = RevertPermutationFor(permutedChipher-1);//KeyTable geht von 0 bis 8099, deshlab -1 weil permutedCipher von 1 bis 8100 ist
                concatenatedDecryptedSymbols += RevertChipher(chiper);
                if (chiper == '-')
                {
                    Debug.WriteLine("Ungültiger Eingabewert");
                }
            }

            return new DecryptedMessage(_message.Id, _message.Timestamp, concatenatedDecryptedSymbols, _message.MessageHeader);
        }

        private int RevertCharacterPair(char concatenatedSymbolPartA, char concatenatedSymbolPartB)
        {
            var keyA = MathematicalMappingLogic.BackTransformationTable[concatenatedSymbolPartA];
            var keyB = MathematicalMappingLogic.BackTransformationTable[concatenatedSymbolPartB];

            return (keyA - 1) * 90 + keyB;
        }

        private int RevertPermutationFor(int permutedChipher)
        {
            if (_keyTable.ContainsValue(permutedChipher))
            {
               return _keyTable.FirstOrDefault(x => x.Value == permutedChipher).Key;
            }
            return permutedChipher;
        }

        private char RevertChipher(int chiper)
        {
            foreach (var symbol in MathematicalMappingLogic.IntervalTable.Keys)
            {
                var interval = MathematicalMappingLogic.IntervalTable[symbol];
                if (chiper >= interval.Start && chiper <= interval.End)
                {
                    return symbol;
                }
            }

            return '-';
        }
    }
}
