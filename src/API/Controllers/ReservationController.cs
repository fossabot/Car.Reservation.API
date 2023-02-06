using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
