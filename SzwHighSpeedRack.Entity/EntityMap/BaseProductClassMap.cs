namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseProductClassMap : IEntityTypeConfiguration<BaseProductClass>
    {
        public void Configure(EntityTypeBuilder<BaseProductClass> builder)
        {
            builder.ToTable("BaseProductClass").HasKey(x => x.Id);
        }
    }
}