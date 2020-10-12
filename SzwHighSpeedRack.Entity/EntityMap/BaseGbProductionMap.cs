namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseGbProductionMap : IEntityTypeConfiguration<BaseGbProduction>
    {
        public void Configure(EntityTypeBuilder<BaseGbProduction> builder)
        {
            builder.ToTable("BaseGbProduction").HasKey(x => x.Id);
        }
    }
}