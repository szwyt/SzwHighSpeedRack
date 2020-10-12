namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdStockOutMap : IEntityTypeConfiguration<PdStockOut>
    {
        public void Configure(EntityTypeBuilder<PdStockOut> builder)
        {
            builder.ToTable("PdStockOut").HasKey(x => x.Id);
        }
    }
}