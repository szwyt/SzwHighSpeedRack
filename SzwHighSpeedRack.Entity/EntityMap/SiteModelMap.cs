namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteModelMap : IEntityTypeConfiguration<SiteModel>
    {
        public void Configure(EntityTypeBuilder<SiteModel> builder)
        {
            builder.ToTable("SiteModel").HasKey(x => x.Id);
        }
    }
}