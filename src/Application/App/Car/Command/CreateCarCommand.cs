using Application.Abstract.Repositories;
using Application.App.Car.Response;
using BCrypt.Net;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;

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
            var hash = BCrypt.Net.BCrypt.HashPassword(request.CPatterNumber, Constants.Salt, false, HashType.SHA256);

            var isCar = await _carRepository.AnyAsync(x => x.Hash == hash, cancellationToken);

            if (isCar)
                throw new BadHttpRequestException("Car number already exist - please select another one");

            var car = request.Adapt<Domain.Models.Car>();
            car.Hash = hash;
            
            _carRepository.Add(car);
            await _carRepository.SaveChangesAsync(cancellationToken);

            return car.Adapt<CarResponse>();
        }
    }
}
