namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteModelColumnMap : IEntityTypeConfiguration<SiteModelColumn>
    {
        public void Configure(EntityTypeBuilder<SiteModelColumn> builder)
        {
            builder.ToTable("SiteModelColumn").HasKey(x => x.Id);
        }
    }
}