using API.Controllers.Requests;
using Application.App.Car.Command;
using Application.App.Car.Query;
using Application.App.Car.Response;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CarResponse>> Get()
        {
            return await _mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost("create")]
        public async Task<CarResponse> Post(AddCarRequest request)
        {
            var command = request.Adapt<CreateCarCommand>();
            return await _mediator.Send(command);
        }

        [HttpPut("{id}/update")]
        public async Task<CarResponse> Put([FromRoute] long id, [FromBody] AddCarRequest request)
        {
            var command = request.Adapt<UpdateCarCommand>();
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}/remove")]
        public async Task<CarResponse> Delete([FromRoute] long id)
        {
            return await _mediator.Send(new DeleteCarCommand { Id = id });
        }
    }
}