using Domain.Models;

namespace Application.Services.Abs
{
    public interface IReceiveMessagesService
    {
        Task<List<ReceiveMessage>> GetAll();
        Task<List<ReceiveMessage>> GetAll(string userName);
        Task<ReceiveMessage> Get(string id);
        Task<ApplicationUser> FromUser(string receiveMessageId);
        Task Delete(string id);
    }
}
