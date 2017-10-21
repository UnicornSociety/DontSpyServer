using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    public class ChannelUser
    {
        [ForeignKey(typeof(Channel))]
        public int ChannelId { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
