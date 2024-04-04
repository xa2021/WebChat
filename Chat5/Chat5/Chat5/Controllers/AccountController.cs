using Chat5.Entities;
using Chat5.Identity;
using Chat5.Identity.Models;
using Chat5.Models;
using Chat5.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Chat5.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<ChatUser> _signInUser;
        private readonly UserManager<ChatUser> _userManager;

        private readonly Chat5DbContext _chat5DbContext;

        public AccountController(SignInManager<ChatUser> signInUser, UserManager<ChatUser> userManager,Chat5DbContext chat5DbContext)
        {
            _signInUser = signInUser;
            _userManager = userManager;
            _chat5DbContext = chat5DbContext;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInUser.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Błąd podczas logowania");
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                ChatUser chatUser = new()
                {
                    NickName = model.NickName,
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(chatUser,model.Password!);
                if (result.Succeeded)
                {
                    // await _signInUser.SignInAsync(chatUser, false);

                    Contact contact = new Contact()
                    {
                        FirstName = model.NickName,
                        UserId = chatUser.Id
                    };

                    await _chat5DbContext.AddAsync(contact);

                    _chat5DbContext.SaveChanges();

                    return RedirectToAction("Login", "Account");   
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            ModelState.AddModelError("", "Błąd podczas rejestracji");

            return View(model);

        }


        public async Task<IActionResult> Logout()
        {
            await _signInUser.SignOutAsync();

            return RedirectToAction("Login","Account");
        }


    }
}
