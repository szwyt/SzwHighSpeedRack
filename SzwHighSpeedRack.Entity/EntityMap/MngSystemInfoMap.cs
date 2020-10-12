namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngSystemInfoMap : IEntityTypeConfiguration<MngSystemInfo>
    {
        public void Configure(EntityTypeBuilder<MngSystemInfo> builder)
        {
            builder.ToTable("MngSystemInfo").HasKey(x => x.Id);
        }
    }
}