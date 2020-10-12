namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngSystemSettingMap : IEntityTypeConfiguration<MngSystemSetting>
    {
        public void Configure(EntityTypeBuilder<MngSystemSetting> builder)
        {
            builder.ToTable("MngSystemSetting").HasKey(x => x.Id);
        }
    }
}