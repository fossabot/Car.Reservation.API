using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class CarReservationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public CarReservationContext()
        {
            
        }


    }
}
