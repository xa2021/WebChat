using Chat5.Entities;
using Chat5.Identity;
using Chat5.Models;
using Chat5.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chat5.CQRS.Partial.Queries
{
    public class CreateNewChatQuery : IRequest<Conversation>
    {
        public Guid[]? ContactIdList { get; set; }
        public string? InputElement { get; set; }      
    }


    public class CreateNewChatHandle : IRequestHandler<CreateNewChatQuery, Conversation>
    {
        private readonly Chat5DbContext _context;
        private readonly ChatIdentityDbContext _identity;
        private readonly ICurrentUserService _currentUserService;

        public CreateNewChatHandle(Chat5DbContext context,ICurrentUserService currentUserService,ChatIdentityDbContext identity)
        {
            _context = context;
            _currentUserService = currentUserService;
            _identity = identity;

        }

        public async  Task<Conversation> Handle(CreateNewChatQuery request, CancellationToken cancellationToken)
        {
            List<GroupMember> members = new List<GroupMember>();
            var  name = "";
            var cc = _currentUserService.UserId;
            var contactId = _context.Contacts.FirstOrDefault(a=>a.UserId == _currentUserService.UserId);




            if (string.IsNullOrEmpty(request.InputElement))
            {
                foreach (var item in request.ContactIdList!)
                {
                    var itemToAdd = _context.Contacts.FirstOrDefault(a => a.ContactId == item);
                    name = name + itemToAdd.FirstName + (!string.IsNullOrEmpty(itemToAdd.LastName) ? itemToAdd.LastName : "");
				}
            }


            Conversation conversation = new Conversation()
            {
                ConversationId = Guid.NewGuid(),
                ConversationName = name
			};          

            foreach (var item in request.ContactIdList)
            {
                members.Add(new GroupMember
                {
                    GroupMemberId = Guid.NewGuid(),
                    JoinTime = DateTime.Now,
                    ContactId = item,
                    ConversationId = conversation.ConversationId
                });
            }
            GroupMember member = new GroupMember()
            {
                GroupMemberId = Guid.NewGuid(),
                JoinTime = DateTime.Now,
                ContactId = contactId.ContactId,
                ConversationId =conversation.ConversationId
            };



            members.Add(member);


            await _context.AddAsync(conversation);        
            await _context.AddRangeAsync(members);

            _context.SaveChanges();



            return conversation;
        }
    }


}
