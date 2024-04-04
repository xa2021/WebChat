using Chat5.Entities;
using Chat5.Entities.Seed;
using Microsoft.EntityFrameworkCore;

namespace Chat5.Models
{
    public class Chat5DbContext:DbContext
    {
        
        public Chat5DbContext(DbContextOptions<Chat5DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Chat5DbContext).Assembly);          


            modelBuilder.Entity<GroupMember>()
                   .HasOne(x => x.Contact)
                   .WithMany(x => x.GroupMembers)
                   .HasForeignKey(x => x.ContactId);


            modelBuilder.Entity<GroupMember>()
                .HasOne(x => x.Conversation)
                .WithMany(x => x.GroupMembers)
                .HasForeignKey(v => v.ConversationId);

            modelBuilder.Entity<Message>()
                .HasOne(a => a.Conversation)
                .WithMany(x => x.Messages)
                .HasForeignKey(y => y.ConversationId);



            modelBuilder.SeedSampleData();
        }


        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Message> Messages { get; set; }


       


    }
}
