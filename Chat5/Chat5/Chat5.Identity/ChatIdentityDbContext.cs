
using Chat5.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat5.Identity
{
    public class ChatIdentityDbContext : IdentityDbContext<ChatUser,ChatRole,Guid>
    {
        

        public ChatIdentityDbContext(DbContextOptions<ChatIdentityDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<IdentityRole>().ToTable("AspNetRoles", "ChatRoles");
            //builder.Entity<IdentityRoleClaim<int>>().ToTable("AspNetRoleClaims", "ChatRolesClaims");
            //builder.Entity<IdentityUserClaim<int>>().ToTable("AspNetUserClaims", "ChatAspNetUserClaims");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "ChatAspNetUserLogins");
            //builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "ChatAspNetUserRoles");
            //builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "ChatAspNetUserTokens");

        }

    }
}
