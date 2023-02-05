using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class CarBrandModelConfiguration : BaseConfiguration<CarBrandModel>
    {
        public override void Configure(EntityTypeBuilder<CarBrandModel> builder)
        {
            
            base.Configure(builder);
        }
    }
}
