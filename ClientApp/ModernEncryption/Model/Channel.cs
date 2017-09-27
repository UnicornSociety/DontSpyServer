using System.Collections.Generic;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using Plugin.SecureStorage;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Channel")]
    public class Channel : IEntity
    {
        [PrimaryKey]
        public int Id { get; set; }

        [ManyToMany(typeof(UserChannel))]
        public List<User> Members { get; set; }

        [OneToMany]
        public List<Message> Messages { get; set; }

        public GroupIndicator ChannelType { get; set; }

        public int KeyReference { get; set; }

        

        
          

        public enum GroupIndicator
        {
            Single, Group
        }

        public Channel()
        {
        }
         
        public Channel(int id, List<User> members, GroupIndicator channelType)
        {
            Id = id;
            Members = members;
            ChannelType = channelType;
            KeyReference = CreateKey();
        }

        private int CreateKey()
        {
            var generateKey = new GenerateKeys();
            var key = generateKey.ProduceKeys(1600);
            var numberKey = 1;
            if (CrossSecureStorage.Current.HasKey("Number"))
            {
                var number = CrossSecureStorage.Current.GetValue("Number");
                numberKey = int.Parse(number);
                numberKey++;
                CrossSecureStorage.Current.SetValue("Number", numberKey.ToString());
            }
            else
            {
                CrossSecureStorage.Current.SetValue("Number", "1");
            }

            CrossSecureStorage.Current.SetValue(numberKey.ToString(), key);
            return numberKey;
        }
    }
}
