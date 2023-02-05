using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class ReservationConfiguration : BaseConfiguration<Reservation>
    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.CarId);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.CarId);

            base.Configure(builder);
        }
    }
}
