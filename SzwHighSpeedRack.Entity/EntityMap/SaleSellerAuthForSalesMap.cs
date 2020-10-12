namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleSellerAuthForSalesMap : IEntityTypeConfiguration<SaleSellerAuthForSales>
    {
        public void Configure(EntityTypeBuilder<SaleSellerAuthForSales> builder)
        {
            builder.ToTable("SaleSellerAuthForSales").HasKey(x => x.Id);
        }
    }
}