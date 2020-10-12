namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseSpecificationsMap : IEntityTypeConfiguration<BaseSpecifications>
    {
        public void Configure(EntityTypeBuilder<BaseSpecifications> builder)
        {
            builder.ToTable("BaseSpecifications").HasKey(x => x.Id);
        }
    }
}