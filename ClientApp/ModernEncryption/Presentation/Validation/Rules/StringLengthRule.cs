using ModernEncryption.Interfaces;

namespace ModernEncryption.Presentation.Validation.Rules
{
    internal class StringLengthRule<T> : IValidationRule<T>
    {
        private readonly int _min;
        private readonly int _max;

        public StringLengthRule(int minInclude, int maxInclude)
        {
            _min = minInclude;
            _max = maxInclude;
        }

        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null) return false;
            var s = value as string;
            if (s == null) return false;

            var stringLength = s.Length;
            if (stringLength < _min) return false;
            if (stringLength > _max) return false;

            return true;
        }
    }
}
