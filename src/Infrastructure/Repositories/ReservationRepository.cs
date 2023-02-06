using Application.Abstract.Repositories;
using Domain.Models;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(CarReservationContext context) : base(context)
        {
        }
    }
}
