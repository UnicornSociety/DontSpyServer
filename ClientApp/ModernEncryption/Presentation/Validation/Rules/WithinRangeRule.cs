using System;
using ModernEncryption.Interfaces;

namespace ModernEncryption.Presentation.Validation.Rules
{
    internal class WithinRangeRule<T> : IValidationRule<T>
    {
        private readonly int _min;
        private readonly int _max;

        public WithinRangeRule(int minInclude, int maxInclude)
        {
            _min = minInclude;
            _max = maxInclude;
        }

        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null) return false;

            var number = Convert.ToInt32(value);
            if (number < _min) return false;
            if (number > _max) return false;

            return true;
        }
    }
}
