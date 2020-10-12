namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleSellerMap : IEntityTypeConfiguration<SaleSeller>
    {
        public void Configure(EntityTypeBuilder<SaleSeller> builder)
        {
            builder.ToTable("SaleSeller").HasKey(x => x.Id);
        }
    }
}