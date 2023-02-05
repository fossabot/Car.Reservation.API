using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal class CarConfiguration : BaseConfiguration<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(x => x.CPatterNumber)
                .IsUnique();

            
            //builder.HasData(new List<Car>
            //{
            //    new() {Id = 1, Brand = "Honda", Model = "CRV", CPatterNumber = @"111 
            //                                                                     11
            //                                                                     1"},
            //    new() {Id = 2, Brand = "Skoda", Model = "Superb", CPatterNumber = "222"},
            //    new() {Id = 3, Brand = "Toyota", Model = "Corolla", CPatterNumber = "333"},
            //    new() {Id = 4, Brand = "Opel", Model = "Vectra", CPatterNumber = "444"},
            //    new() {Id = 5, Brand = "BMW", Model = "x7", CPatterNumber = "555"},
            //    new() {Id = 6, Brand = "Mercedes", Model = "GLC", CPatterNumber = "666"}
            //});

            base.Configure(builder);
        }
    }
}
