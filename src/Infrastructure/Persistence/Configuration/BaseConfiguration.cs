using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetUtcDate()");

            builder.Property(x => x.EditedAt)
                .ValueGeneratedOnUpdate()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetUtcDate()");
        }
    }
}
