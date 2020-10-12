namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SysMobileCodeMap : IEntityTypeConfiguration<SysMobileCode>
    {
        public void Configure(EntityTypeBuilder<SysMobileCode> builder)
        {
            builder.ToTable("SysMobileCode").HasKey(x => x.Id);
        }
    }
}