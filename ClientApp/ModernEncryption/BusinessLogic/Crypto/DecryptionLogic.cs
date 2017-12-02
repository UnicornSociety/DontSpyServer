using System.Collections.Generic;
using System.Diagnostics;
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
                var chiper = RevertPermutationFor(permutedChipher, _keyTable);
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

            return (keyA - 1) * 40 + keyB;
        }

        private int RevertPermutationFor(int permutedChipher, Dictionary<int, int> keyTable)
        {
            if (keyTable.ContainsKey(permutedChipher))
                return keyTable[permutedChipher];
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
