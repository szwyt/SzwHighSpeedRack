namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseProductGbClassMap : IEntityTypeConfiguration<BaseProductGbClass>
    {
        public void Configure(EntityTypeBuilder<BaseProductGbClass> builder)
        {
            builder.ToTable("BaseProductGbClass").HasKey(x => x.Id);
        }
    }
}