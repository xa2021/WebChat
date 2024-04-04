namespace Chat5.Entities
{
    public class GroupMember
    {
      public Guid GroupMemberId {  get; set; }
        public DateTime JoinTime { get; set; }
        public DateTime LeftTime { get; set; }

        public  Contact Contact { get; set; }
        public  Guid ContactId { get; set; }
        public  Conversation Conversation { get; set; }
        public  Guid? ConversationId { get; set; }
    }
}
