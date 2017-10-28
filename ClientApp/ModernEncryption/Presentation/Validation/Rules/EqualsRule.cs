using ModernEncryption.Interfaces;

namespace ModernEncryption.Presentation.Validation.Rules
{
    internal class EqualsRule<T> : IValidationRule<T>
    {
        private readonly T _str;

        public EqualsRule(T str)
        {
            _str = str;
        }

        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null) return false;

            var text = value as string;
            return text != null && text.Equals(_str);
        }
    }
}
