namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleSellerAuthDetailMap : IEntityTypeConfiguration<SaleSellerAuthDetail>
    {
        public void Configure(EntityTypeBuilder<SaleSellerAuthDetail> builder)
        {
            builder.ToTable("SaleSellerAuthDetail").HasKey(x => x.Id);
        }
    }
}