using Chat5.Entities;
using Chat5.Models;
using Chat5.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chat5.CQRS.Partial.Queries
{
    public class GetConversationQuery:IRequest<List<GroupMember>>
    {
        public string? query { get; set; }
    }

    public class GetConversationHandler : IRequestHandler<GetConversationQuery,List<GroupMember>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly Chat5DbContext _chat5DbContext;
        public GetConversationHandler(ICurrentUserService currentUserService, Chat5DbContext chat5DbContext)
        {
            _currentUserService = currentUserService;
            _chat5DbContext = chat5DbContext;
        }

        public async Task<List<GroupMember>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            List<GroupMember> convers = new List<GroupMember>();
            var contactId = _chat5DbContext.Contacts.FirstOrDefault(c => c.UserId == _currentUserService.UserId);

            if (string.IsNullOrEmpty(request.query))
            {
               
               
                if (contactId != null)
                {
                    var conversations = _chat5DbContext.GroupMembers.Include(a => a.Conversation)
                        .Where(a => a.ContactId == contactId.ContactId).Select(a => a)
                        .OrderByDescending(v => v.JoinTime).ToList();

                    convers.AddRange(conversations);

                    return convers;
                }
            }
            else
            {
                var conversations = _chat5DbContext.GroupMembers.Include(a => a.Conversation)
                    .Where(a => a.ContactId == contactId.ContactId && a.Conversation.ConversationName.ToLower().Contains(request.query.ToLower()) ).Select(a => a)
                    .OrderByDescending(v => v.JoinTime).ToList();

                convers.AddRange(conversations);

                return convers;
            }

            return convers;
        }
    }







}
