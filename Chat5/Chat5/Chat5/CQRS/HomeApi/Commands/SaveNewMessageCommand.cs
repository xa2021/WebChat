using Chat5.Entities;
using Chat5.Models;
using Chat5.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Chat5.CQRS.HomeApi.Commands
{
    public class SaveNewMessageCommand: IRequest<Message>
    {

        public required string Text { get; set; }
        public required Guid ConversationId { get; set; }

    }


    public class SaveNewMessageHandler : IRequestHandler<SaveNewMessageCommand,Message>
    {
        private readonly ICurrentUserService _userService;
        private readonly Chat5DbContext _dbContext;

        public SaveNewMessageHandler(ICurrentUserService userService, Chat5DbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }

        public async Task<Message> Handle(SaveNewMessageCommand request, CancellationToken cancellationToken)
        {                       

            Message message = new Message
            {
                MessageId = Guid.NewGuid(),
                SentDateTime = DateTime.UtcNow,
                ConversationId = request.ConversationId,
                Text = request.Text,
                From = _userService.UserId,
                Name = _userService.UserNickname
            };

            await _dbContext.AddAsync(message);
            _dbContext.SaveChanges();

            return message;
        }
    }







}
