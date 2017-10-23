namespace ModernEncryption.Model
{
    public class SelectableData<T>
    {
        public T Data { get; }
        public bool Selected { get; set; }

        public SelectableData(T data, bool selected = false)
        {
            Data = data;
            Selected = selected;
        }
    }
}
