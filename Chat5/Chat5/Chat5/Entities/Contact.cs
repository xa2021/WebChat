using System.ComponentModel.DataAnnotations;

namespace Chat5.Entities
{
    public class Contact
    {       
        public Guid ContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Number {  get; set; }

        public Guid UserId { get; set; }

        public List<GroupMember>? GroupMembers { get; set; }

    }
}
