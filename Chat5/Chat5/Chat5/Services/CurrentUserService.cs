
using Chat5.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Chat5.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<ChatUser> _userManager;
        private readonly SignInManager<ChatUser> _signInManager;
        private readonly IHttpContextAccessor _accessor;


        public CurrentUserService( UserManager<ChatUser> userManager, IHttpContextAccessor accessor,SignInManager<ChatUser> signInManager)
        {
            _accessor = accessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Guid UserId
        {
            get
            {
                Guid.TryParse(_accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out var res);
                return res;
            }
        }        
        public string UserName => _accessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        public string? UserNickname => _userManager.Users.FirstOrDefault(a => a.Id == this.UserId)?.NickName;

    }
}
