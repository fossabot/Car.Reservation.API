using Application.Abstract.Repositories;
using Application.App.Car.Response;
using Mapster;
using MediatR;

namespace Application.App.Car.Command
{
    public class UpdateCarCommand : IRequest<CarResponse>
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CPatterNumber { get; set; }
    }

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarResponse>
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.FindByIdAsync(request.Id, cancellationToken);

            car.Brand = string.IsNullOrEmpty(request.Brand) ? car.Brand : request.Brand;
            car.Model = string.IsNullOrEmpty(request.Model) ? car.Model : request.Model;
            car.CPatterNumber = string.IsNullOrEmpty(request.CPatterNumber) ? car.CPatterNumber : request.CPatterNumber;

            if (car == null)
                throw new ArgumentException($"Car {request.Id} is not created");

            _carRepository.Update(car);
            await _carRepository.SaveChangesAsync(cancellationToken);

            return car.Adapt<CarResponse>();
        }
    }
}
