namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQrcodePrintedLogMap : IEntityTypeConfiguration<PdQrcodePrintedLog>
    {
        public void Configure(EntityTypeBuilder<PdQrcodePrintedLog> builder)
        {
            builder.ToTable("PdQrcodePrintedLog").HasKey(x => x.Id);
        }
    }
}