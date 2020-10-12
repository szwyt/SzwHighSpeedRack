namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteSinglePageMap : IEntityTypeConfiguration<SiteSinglePage>
    {
        public void Configure(EntityTypeBuilder<SiteSinglePage> builder)
        {
            builder.ToTable("SiteSinglePage").HasKey(x => x.Id);
        }
    }
}