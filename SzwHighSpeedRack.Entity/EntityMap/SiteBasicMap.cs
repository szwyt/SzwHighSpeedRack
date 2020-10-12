namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteBasicMap : IEntityTypeConfiguration<SiteBasic>
    {
        public void Configure(EntityTypeBuilder<SiteBasic> builder)
        {
            builder.ToTable("SiteBasic").HasKey(x => x.Id);
        }
    }
}