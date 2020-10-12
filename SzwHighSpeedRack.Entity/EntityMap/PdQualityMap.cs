namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQualityMap : IEntityTypeConfiguration<PdQuality>
    {
        public void Configure(EntityTypeBuilder<PdQuality> builder)
        {
            builder.ToTable("PdQuality").HasKey(x => x.Id);
        }
    }
}