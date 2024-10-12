using Domain.Models;

namespace Data.Repos.Abs
{
    public interface IReceiveMessagesRepository
    {
        Task<List<ReceiveMessage>> GetAll();
        Task<List<ReceiveMessage>> GetAll(string userName);
        Task<ReceiveMessage> Get(string id);
        Task<ApplicationUser> FromUser(string receiveMessageId);
        Task Delete(string id);
    }
}
