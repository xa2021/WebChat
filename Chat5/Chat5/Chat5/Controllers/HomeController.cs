using Chat5.CQRS.Partial.Queries;
using Chat5.Entities;
using Chat5.Models;
using Chat5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Chat5.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {         
        public async Task< IActionResult> Index(GetConversationQuery query)
        {         
        var a = await Mediator.Send(query);
            return View(a);
        }

    }
}
