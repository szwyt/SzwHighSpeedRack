namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdBatCodeMap : IEntityTypeConfiguration<PdBatCode>
    {
        public void Configure(EntityTypeBuilder<PdBatCode> builder)
        {
            builder.ToTable("PdBatCode").HasKey(x => x.Id);
        }
    }
}