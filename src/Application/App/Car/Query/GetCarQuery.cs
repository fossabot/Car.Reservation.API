using Application.Abstract.Repositories;
using Application.App.Car.Response;
using Mapster;
using MediatR;

namespace Application.App.Car.Query
{
    public class GetAllCarsQuery : IRequest<IEnumerable<CarResponse>>
    {
    }

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarResponse>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.ListAsync(cancellationToken);
            
            return cars.Adapt<IEnumerable<CarResponse>>();
        }
    }
}
