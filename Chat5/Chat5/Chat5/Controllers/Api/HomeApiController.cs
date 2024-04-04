
using Chat5.CQRS.HomeApi.Commands;
using Chat5.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat5.Controllers.Api
{
	[Route("api/[controller]/[action]")]
	public class HomeApiController : BaseController
	{
        private readonly ICurrentUserService _userService;
        public HomeApiController(ICurrentUserService userService)
        {
            _userService = userService;
        }
		
        public async Task<IActionResult> AddNewMessage([FromBody] SaveNewMessageCommand command)
        {
            var a = await Mediator.Send(command);
            return Json(new { Message = a, UserCurrentLog = _userService.UserId });
        }


	}
}
