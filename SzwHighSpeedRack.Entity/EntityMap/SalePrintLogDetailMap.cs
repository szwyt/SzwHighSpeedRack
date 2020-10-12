namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalePrintLogDetailMap : IEntityTypeConfiguration<SalePrintLogDetail>
    {
        public void Configure(EntityTypeBuilder<SalePrintLogDetail> builder)
        {
            builder.ToTable("SalePrintLogDetail").HasKey(x => x.Id);
        }
    }
}