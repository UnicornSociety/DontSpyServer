using System;
using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class EncryptionLogic : IEncrypt
    {
        private readonly char[] _messageTextSymbols;
        private readonly Message _message;
        private readonly Dictionary<int, int> _keyTable;

        public EncryptionLogic(Message message, Dictionary<int, int> keyTable)
        {
            _message = message;
            _messageTextSymbols = message.Text.ToCharArray();
            _keyTable = keyTable;
        }

        public Message Encrypt()
        {
            var concatenatedEncryptedSymbols = string.Empty;

            foreach (var symbol in _messageTextSymbols)
            {
                var chipher = CreateChipher(symbol);
                var permutedChipher = RunPermutationFor(chipher-1);//KeyTable geht von 0 bis 8099, deshlab -1 weil cipher von 1 bis 8100 ist

                concatenatedEncryptedSymbols += CreateCharacterPair(permutedChipher);
            }

            _message.Text = concatenatedEncryptedSymbols;
            return _message;
        }

        private int CreateChipher(char symbol)
        {
            var rnd = new Random();
            var interval = MathematicalMappingLogic.IntervalTable[symbol];
            return rnd.Next(interval.Start, interval.End + 1);
        }

        private int RunPermutationFor(int chipher)
        {
            if (_keyTable.ContainsKey(chipher))
                return _keyTable[chipher];
            return chipher;
        }

        private string CreateCharacterPair(int permutedChipher)
        {
            var keyA = (permutedChipher - 1) / 90 + 1;
            var keyB = (permutedChipher - 1) % 90 + 1;
            return "" + MathematicalMappingLogic.TransformationTable[keyA] + MathematicalMappingLogic.TransformationTable[keyB];
        }
    }
}
