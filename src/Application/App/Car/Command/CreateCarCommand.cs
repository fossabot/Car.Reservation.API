using Application.Abstract.Repositories;
using Application.App.Car.Response;
using Mapster;
using MediatR;

namespace Application.App.Car.Command
{
    public class CreateCarCommand : IRequest<CarResponse>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CPatterNumber { get; set; }
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarResponse>
    {
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = request.Adapt<Domain.Models.Car>();

            _carRepository.Add(car);
            await _carRepository.SaveChangesAsync(cancellationToken);

            return car.Adapt<CarResponse>();
        }
    }
}
