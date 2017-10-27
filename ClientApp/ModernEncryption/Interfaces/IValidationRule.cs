namespace ModernEncryption.Interfaces
{
    internal interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
