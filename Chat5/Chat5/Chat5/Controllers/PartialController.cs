using Chat5.CQRS.Partial.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Chat5.Controllers
{
    public class PartialController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Message([FromBody] GetMessageQuery query)
        {
            var q =await Mediator.Send(query);
            return PartialView("MessagePartial",q);
        }

        [HttpPost]
        public async Task<IActionResult> GetUsersToNewConversation(GetUsersToNewConversationQuery query)
        {
            var data = await Mediator.Send(query);
            return PartialView("ContactPartial",data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewChat([FromBody]CreateNewChatQuery query)
        {
            var data = await Mediator.Send(query);            
            return PartialView("NewConversationPartial", data);
        }

        public async Task<IActionResult> SearchConversation([FromBody] GetConversationQuery query)
        {
            var result = await Mediator.Send(query);
            return PartialView( result);
        }
    }
}
