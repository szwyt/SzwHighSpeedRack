namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseQualityStandardMap : IEntityTypeConfiguration<BaseQualityStandard>
    {
        public void Configure(EntityTypeBuilder<BaseQualityStandard> builder)
        {
            builder.ToTable("BaseQualityStandard").HasKey(x => x.Id);
        }
    }
}