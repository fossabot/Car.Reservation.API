using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class CarBrandConfiguration : BaseConfiguration<CarBrand>
    {
        public override void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            
            base.Configure(builder);
        }
    }
}
