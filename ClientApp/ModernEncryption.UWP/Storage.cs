using Windows.Storage;
using ModernEncryption.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(Storage))]
namespace ModernEncryption.UWP
{
    public class Storage : Interfaces.IStorage
    {
        public string Path()
        {
            return ApplicationData.Current.LocalFolder.Path;
        }
    }
}
