namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SitelinkMap : IEntityTypeConfiguration<Sitelink>
    {
        public void Configure(EntityTypeBuilder<Sitelink> builder)
        {
            builder.ToTable("Sitelink").HasKey(x => x.Id);
        }
    }
}