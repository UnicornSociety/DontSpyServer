using System.Collections.Generic;
using System.Threading.Tasks;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    internal interface IMessageService
    {
        Task<List<EncryptedMessage>> GetMessage(int userId);
        Task<bool> SendMessage(IMessage message);
    }
}
