using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using SQLite.Net;
using Xamarin.Forms;

namespace ModernEncryption
{
    internal class DependencyManager
    {
        public static SQLiteConnection Database { get; } = DependencyService.Get<IStorage>().GetConnection();
        public static ChannelsPage ChannelsPage { get; } = new ChannelsPage();
        public static ContactsPage ContactsPage { get; } = new ContactsPage();
        public static IChannelService ChannelService { get; } = new ChannelService();
    }
}
