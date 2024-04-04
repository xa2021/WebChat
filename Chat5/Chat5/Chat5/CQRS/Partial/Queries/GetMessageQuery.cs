using Chat5.Entities;
using Chat5.Models;
using Chat5.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat5.CQRS.Partial.Queries
{
    public class GetMessageQuery : IRequest<GetMessagesResponse>
    {
        public Guid ConversationId { get; set; }
    }


    public class GetMessageHandler : IRequestHandler<GetMessageQuery, GetMessagesResponse>
    {
        private readonly Chat5DbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetMessageHandler(Chat5DbContext context,ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<GetMessagesResponse> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var messages = _context.Messages.Where(a => a.ConversationId == request.ConversationId).Select(a => a).ToList().OrderBy(a=>a.SentDateTime);

            var response = new GetMessagesResponse();
           
                foreach (var message in messages)
                {

                response.Messages.Add(new Message
                {
                    Text = message.Text,
                    MessageId = message.MessageId,
                    From = message.From,
                    SentDateTime =  message.SentDateTime,
                    Name = message.Name,
                }) ;
            
                }
                response.CurrentLogUser = _currentUserService.UserId;
                return response;
        }
    }

    public class GetMessagesResponse
    {
        public List<Message> Messages { get; set; } = new List<Message>();

        public Guid CurrentLogUser { get; set; }
    }  
    
}






