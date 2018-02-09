using System;
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

        public DecryptionLogic(Message message)
        {
            _message = message;
            _messageTextSymbols = message.Text.ToCharArray();
        }

        public DecryptedMessage Decrypt()
        {
            var concatenatedDecryptedSymbols = string.Empty;

            for (var i = 0; i < _messageTextSymbols.Length; i++)
            {
                var permutedChipher = RevertCharacterPair(_messageTextSymbols[i], _messageTextSymbols[++i]);
                var chiper = RevertPermutationFor(permutedChipher);
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
            if (MathematicalMappingLogic.KeyTable.ContainsValue(permutedChipher))
                {
                return MathematicalMappingLogic.KeyTable.FirstOrDefault(x => x.Value == permutedChipher).Key;
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
