using CarSales.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.Infrastructure.Persistence.EF.Configuration.Base;

internal abstract class AuditableEntityConfigurationBase<TEntity> : EntityConfigurationBase<TEntity>
    where TEntity : AuditableEntityBase
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.ModifiedBy).IsRequired().HasDefaultValue("system");
        builder.Property(x => x.UpdatedDateTime).IsRequired().ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
        builder.Property(x => x.DeletedDateTime);
    }
}

