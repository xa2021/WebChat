using Microsoft.EntityFrameworkCore;

namespace Chat5.Entities.Seed
{
    public static class SeedData
    {

        public static void SeedSampleData( this ModelBuilder builder)
        {
       


            var contact = new Contact
            {
                ContactId = new Guid("4641435b-150f-4119-be3d-79ac6f5dbb89"),
                FirstName = "Rafał",
                LastName = "NN",
                UserId= new Guid("B90F513D-5B7A-43BC-7E3D-08DC3DD09D7F")
            };


            var contact2 = new Contact
            {
                ContactId = new Guid("a5610a23-0b7c-4790-852a-c411edaa5db1"),
                FirstName = "Darek",
                LastName = "Nieara",
                UserId = new Guid("6DFC52B2-3A59-4ED9-F302-08DC41C91E0B")
            };




            var conversation = new Conversation
            {
                ConversationId = new Guid("0620fc74-3645-404e-93cf-cb0673453349"),
                ConversationName ="Testowe2"
            };


            var conversation2 = new Conversation
            {
                ConversationId = new Guid("0620fc74-3645-404e-93cf-cb0673453342"),
                ConversationName = "Testowe 3343"
            };



            var group3 = new GroupMember
            {
                GroupMemberId = new Guid("d5b19dcb-dca9-4cbf-b6f0-7d541db0da12"),
                JoinTime = DateTime.Now,
                LeftTime = DateTime.Now.AddDays(-1),
                ConversationId = conversation.ConversationId,
                ContactId = contact.ContactId,
            };


            var group = new GroupMember
            {
                GroupMemberId = new Guid("d5b19dcb-dca9-4cbf-b6f0-7d541db0da26"),
                JoinTime = DateTime.Now,
                LeftTime = DateTime.Now.AddDays(-1),
                ConversationId = conversation.ConversationId,
                ContactId = contact.ContactId,
            };


            var group2 = new GroupMember
            {
                GroupMemberId = new Guid("a547818e-894f-46ab-a9ca-191cea5d25f7"),
                JoinTime = DateTime.Now,
                LeftTime = DateTime.Now,
                ConversationId = conversation.ConversationId,
                ContactId = contact2.ContactId,
            };



            var message = new Message
            {
                MessageId = new Guid("1ea1d5af-d77f-4594-b7d4-0fe0785521ce"),
                From = contact.ContactId,
                Text = "test sdajdfskjfdsjfdskl",
                SentDateTime = DateTime.Now,
                ConversationId= conversation.ConversationId
            };



            var message2 = new Message
            {
                MessageId = new Guid("9ce32327-e691-4cc5-8355-97f8caf41a4c"),
                From = contact2.ContactId,
                Text = "test dfgfdg",
                SentDateTime = DateTime.Now,
                ConversationId = conversation.ConversationId
            };



            builder.Entity<Contact>().HasData(contact);
            builder.Entity<Conversation>().HasData(conversation);
            builder.Entity<GroupMember>().HasData(group);
            builder.Entity<Message>().HasData(message);
            builder.Entity<Contact>().HasData(contact2);
            builder.Entity<Message>().HasData(message2);
            builder.Entity<GroupMember>().HasData(group2);
            builder.Entity<GroupMember>().HasData(group3);
            builder.Entity<Conversation>().HasData(conversation2);
        }

    }
}
