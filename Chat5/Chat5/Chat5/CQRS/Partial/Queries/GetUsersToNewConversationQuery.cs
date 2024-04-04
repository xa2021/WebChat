using Chat5.Entities;
using Chat5.Models;
using Chat5.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chat5.CQRS.Partial.Queries
{
    public class GetUsersToNewConversationQuery : IRequest<List<Contact>>
    {
    }
    public class GetUsersToNewConversationHandler : IRequestHandler<GetUsersToNewConversationQuery, List<Contact>>
    {
        private readonly Chat5DbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetUsersToNewConversationHandler(Chat5DbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<List<Contact>> Handle(GetUsersToNewConversationQuery request, CancellationToken cancellationToken)
        {
            var contact = _context.Contacts.Where(c => c.UserId != _currentUserService.UserId).Select(a => a).ToList();
            List<Contact> contactList = new List<Contact>();
           
            
            foreach (var item in contact)
            {
                contactList.Add(new Contact
                {
                    ContactId = item.ContactId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Number = item.Number,

                });
            }
            return contactList;
        }
    }
}
