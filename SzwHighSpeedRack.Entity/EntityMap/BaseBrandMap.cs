namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseBrandMap : IEntityTypeConfiguration<BaseBrand>
    {
        public void Configure(EntityTypeBuilder<BaseBrand> builder)
        {
            builder.ToTable("BaseBrand").HasKey(x => x.Id);
        }
    }
}