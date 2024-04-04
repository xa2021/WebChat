using System.ComponentModel.DataAnnotations;

namespace Chat5.Entities
{
    public class Conversation
    {
        
        public Guid ConversationId { get;set; }
        public string? ConversationName { get;set;}
        public   List<GroupMember>? GroupMembers { get; set; }
        public List<Message> Messages { get; set; }
    }
}
