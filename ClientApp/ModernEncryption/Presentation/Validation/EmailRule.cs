using System.Text.RegularExpressions;
using ModernEncryption.Interfaces;

namespace ModernEncryption.Presentation.Validation
{
    internal class EmailRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            return value != null && new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(value as string).Success;
        }
    }
}
