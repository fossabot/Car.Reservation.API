using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class CarReservationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
