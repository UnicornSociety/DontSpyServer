using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("ChannelUser")]
    public class ChannelUser
    {
        [ForeignKey(typeof(Channel)), Column("channelId"), MaxLength(40)]
        public string ChannelId { get; set; }

        [ForeignKey(typeof(User)), Column("userId"), MaxLength(40)]
        public string UserId { get; set; }
    }
}
