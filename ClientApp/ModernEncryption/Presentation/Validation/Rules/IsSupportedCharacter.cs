using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;

namespace ModernEncryption.Presentation.Validation.Rules
{
    internal class IsSupportedCharacter<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null) return false;

            var text = value as string;
            return text != null && text.ToCharArray().All(messageCharacter => MathematicalMappingLogic.IntervalTable.ContainsKey(messageCharacter));
        }
    }
}
