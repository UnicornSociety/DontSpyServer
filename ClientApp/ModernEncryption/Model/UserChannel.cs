using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    public class UserChannel
    {
        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ForeignKey(typeof(Channel))]
        public int ChannelId { get; set; }
    }
}
