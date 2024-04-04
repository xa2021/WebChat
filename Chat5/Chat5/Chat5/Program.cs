using Chat5;
using Chat5.Identity;
using Chat5.Models;
using Chat5.Models.Repositories;
using Chat5.Profiles;
using Chat5.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.RegisterIdentityService(builder.Configuration); // dodaæ, aby zarejestriwa babsz service ciollections w identity 


builder.Services.AddDbContext<Chat5DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChatDb"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddScoped<ICurrentUserService,CurrentUserService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<MessageHub>("/messagehub");


app.Run();
