using CarSales.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.Infrastructure.Persistence.EF.Configuration.Base;

internal abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase
{
    protected abstract void ConfigureInternal(EntityTypeBuilder<TEntity> builder);

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureInternal(builder);

        builder.Property(x => x.CreatedDateTime)
            .IsRequired()
            .ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
    }
}

