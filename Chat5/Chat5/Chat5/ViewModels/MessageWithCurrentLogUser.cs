using Chat5.Entities;

namespace Chat5.ViewModels
{
    public class MessageWithCurrentLogUser:Message
    {
        public Guid CurrentLog { get; set; }
    }
}
