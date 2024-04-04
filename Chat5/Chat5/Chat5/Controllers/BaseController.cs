using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat5.Controllers
{
    public class BaseController : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

    }
}
