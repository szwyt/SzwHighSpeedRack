namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQualityHighCodeMap : IEntityTypeConfiguration<PdQualityHighCode>
    {
        public void Configure(EntityTypeBuilder<PdQualityHighCode> builder)
        {
            builder.ToTable("PdQualityHighCode").HasKey(x => x.Id);
        }
    }
}