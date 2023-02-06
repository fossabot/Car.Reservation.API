using Application.Abstract.Repositories;
using Application.App.Car.Response;
using Mapster;
using MediatR;

namespace Application.App.Car.Command
{
    public class DeleteCarCommand : IRequest<CarResponse>
    {
        public long Id { get; set; }
    }

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, CarResponse>
    {
        private readonly ICarRepository _carRepository;

        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.FindByIdAsync(request.Id, cancellationToken);

            if (car == null)
                throw new ArgumentException($"Car {request.Id} is deleted");

            _carRepository.Delete(car);
            await _carRepository.SaveChangesAsync(cancellationToken);

            return car.Adapt<CarResponse>();
        }
    }
}
