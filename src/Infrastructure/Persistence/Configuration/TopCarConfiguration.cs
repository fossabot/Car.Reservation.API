using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class TopCarConfiguration : BaseConfiguration<TopCar>
    {
        public override void Configure(EntityTypeBuilder<TopCar> builder)
        {

            base.Configure(builder);
        }
    }
}
