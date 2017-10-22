using System.Diagnostics;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class DecryptionLogic
    {
        private readonly char[] _messageTextSymbols;
        private Message _message;

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

            return new DecryptedMessage(_message.Id, _message.Timestamp, concatenatedDecryptedSymbols);
        }

        private int RevertCharacterPair(char concatenatedSymbolPartA, char concatenatedSymbolPartB)
        {
            var keyA = MathematicalMappingLogic.BackTransformationTable[concatenatedSymbolPartA];
            var keyB = MathematicalMappingLogic.BackTransformationTable[concatenatedSymbolPartB];

            return (keyA - 1) * 40 + keyB;
        }

        private int RevertPermutationFor(int permutedChipher)
        {
            if (MathematicalMappingLogic.KeyTable.ContainsKey(permutedChipher))
                return MathematicalMappingLogic.KeyTable[permutedChipher];
            return permutedChipher;
        }

        private char RevertChipher(int chiper)
        {
            foreach (var symbol in MathematicalMappingLogic.TransformationTable.Values)
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
