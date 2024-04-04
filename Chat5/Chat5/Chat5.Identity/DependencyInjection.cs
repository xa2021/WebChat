using Chat5.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat5.Identity
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterIdentityService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ChatIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ChatIdentity"));
            });


            services.AddIdentity<ChatUser, ChatRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ChatIdentityDbContext>();
            
            




            return services;
        }





    }
}
