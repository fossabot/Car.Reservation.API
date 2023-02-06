using Application.Abstract.Repositories;
using Application.App.Car.Response;
using Domain.Models;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarReservationContext context) : base(context)
        {
        }

    }
}
