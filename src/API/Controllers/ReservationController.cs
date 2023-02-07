using API.Controllers.Requests;
using Application.App.Car.Command;
using Application.App.Car.Query;
using Application.App.Reservation.Command;
using Application.App.Reservation.Query;
using Application.App.Reservation.Response;
using Mapster;
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

        [HttpGet]
        public async Task<IEnumerable<ReservationResponse>> Get()
        {
            return await _mediator.Send(new GetReservationQuery());
        }

        [HttpPost("create")]
        public async Task<ReservationResponse> Post(AddReservationRequest request)
        {
            var command = request.Adapt<CreateReservationCommand>();
            return await _mediator.Send(command);
        }

    }
}
