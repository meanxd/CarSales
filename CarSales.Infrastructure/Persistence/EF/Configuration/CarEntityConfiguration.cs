using CarSales.Domain.Entities;
using CarSales.Infrastructure.Persistence.EF.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.Infrastructure.Persistence.EF.Configuration;

internal sealed class CarEntityConfigurationn : AuditableEntityConfigurationBase<CarEntity>
{
    private const string TableName = "Cars";

    protected override void ConfigureInternal(EntityTypeBuilder<CarEntity> builder)
    {
        builder.ToTable(TableName);

        builder.Property(x => x.Make).IsRequired();
        builder.Property(x => x.Model).IsRequired();
    }
}
