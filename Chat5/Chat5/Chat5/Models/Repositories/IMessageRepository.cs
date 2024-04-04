using Chat5.Entities;

namespace Chat5.Models.Repositories
{
    public interface IMessageRepository
    {

        Task<IEnumerable<Message>> GetAllMessageAsync();
        Task GetMessage(Guid messageId);
        Task DeleteMessage(Guid messageId);


    }
}
