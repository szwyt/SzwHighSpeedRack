namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngSettingMap : IEntityTypeConfiguration<MngSetting>
    {
        public void Configure(EntityTypeBuilder<MngSetting> builder)
        {
            builder.ToTable("MngSetting").HasKey(x => x.Id);
        }
    }
}