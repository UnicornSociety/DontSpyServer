using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using SQLite.Net;
using Xamarin.Forms;

namespace ModernEncryption
{
    internal class DependencyManager
    {
        private static ChannelsPage _channelsPage;
        private static ContactsPage _contactPage;
        private static SQLiteConnection _database;
        private static IChannelService _channelService;
        private static AnchorPage _anchorPage;

        public static SQLiteConnection Database => _database ?? (_database = DependencyService.Get<IStorage>().GetConnection());
        public static ChannelsPage ChannelsPage => _channelsPage ?? (_channelsPage = new ChannelsPage());
        public static ContactsPage ContactsPage => _contactPage ?? (_contactPage = new ContactsPage());
        public static IChannelService ChannelService => _channelService ?? (_channelService = new ChannelService());
        public static User Me { get; set; }
        public static AnchorPage AnchorPage => _anchorPage ?? (_anchorPage = new AnchorPage());
    }
}
