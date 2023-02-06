using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure
{
    public static class Extensions
    {
        public static void DateTimeConvertor(this ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(v => DateTime.SpecifyKind(v, DateTimeKind.Utc), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                }
            }
        }

        public static void FullFillBaseEntity(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();

            if (entries.Any(x => x.Entity is not BaseEntity))
                return;

            foreach (var entry in entries.Where(entry => entry.Entity is BaseEntity))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Property(nameof(BaseEntity.EditedAt)).CurrentValue = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
