namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleSellerAuthMap : IEntityTypeConfiguration<SaleSellerAuth>
    {
        public void Configure(EntityTypeBuilder<SaleSellerAuth> builder)
        {
            builder.ToTable("SaleSellerAuth").HasKey(x => x.Id);
        }
    }
}