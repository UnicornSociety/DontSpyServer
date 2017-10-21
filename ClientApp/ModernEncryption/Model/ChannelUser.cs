using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    public class ChannelUser
    {
        [ForeignKey(typeof(Channel))]
        public string ChannelId { get; set; }

        [ForeignKey(typeof(User))]
        public string UserId { get; set; }
    }
}
