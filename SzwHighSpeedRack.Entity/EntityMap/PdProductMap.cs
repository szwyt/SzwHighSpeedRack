namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdProductMap : IEntityTypeConfiguration<PdProduct>
    {
        public void Configure(EntityTypeBuilder<PdProduct> builder)
        {
            builder.ToTable("PdProduct").HasKey(x => x.Id);
        }
    }
}