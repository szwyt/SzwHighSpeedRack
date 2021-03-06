namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteCategoryMap : IEntityTypeConfiguration<SiteCategory>
    {
        public void Configure(EntityTypeBuilder<SiteCategory> builder)
        {
            builder.ToTable("SiteCategory").HasKey(x => x.Id);
        }
    }
}