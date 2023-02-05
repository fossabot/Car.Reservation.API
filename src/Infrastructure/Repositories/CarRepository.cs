using Application.Abstract.Repositories;
using Domain.Models;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarReservationContext context) : base(context)
        {
        }
    }
}
