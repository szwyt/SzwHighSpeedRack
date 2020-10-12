namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdWorkshopMap : IEntityTypeConfiguration<PdWorkshop>
    {
        public void Configure(EntityTypeBuilder<PdWorkshop> builder)
        {
            builder.ToTable("PdWorkshop").HasKey(x => x.Id);
        }
    }
}