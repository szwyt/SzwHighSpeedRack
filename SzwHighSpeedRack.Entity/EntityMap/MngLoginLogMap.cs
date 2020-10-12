namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngLoginLogMap : IEntityTypeConfiguration<MngLoginLog>
    {
        public void Configure(EntityTypeBuilder<MngLoginLog> builder)
        {
            builder.ToTable("MngLoginLog").HasKey(x => x.Id);
        }
    }
}