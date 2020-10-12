namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalePrintLogMap : IEntityTypeConfiguration<SalePrintLog>
    {
        public void Configure(EntityTypeBuilder<SalePrintLog> builder)
        {
            builder.ToTable("SalePrintLog").HasKey(x => x.Id);
        }
    }
}