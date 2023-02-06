using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Context
{
    public class CarReservationContext : DbContext
    {
        private readonly IConfiguration _configuration;


        public CarReservationContext(DbContextOptions<CarReservationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnection"]);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.DateTimeConvertor();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.FullFillBaseEntity();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.FullFillBaseEntity();

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
