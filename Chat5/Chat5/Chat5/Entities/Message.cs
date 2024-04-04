namespace Chat5.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public Guid From { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public DateTime SentDateTime { get; set; }

        public Conversation Conversation { get; set; }
        public Guid ConversationId { get; set; }

    }
}
