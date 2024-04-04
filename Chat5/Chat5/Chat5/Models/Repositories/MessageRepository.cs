using Chat5.Entities;

namespace Chat5.Models.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Task DeleteMessage(Guid messageId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetAllMessageAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetMessage(Guid messageId)
        {
            throw new NotImplementedException();
        }
    }
}
