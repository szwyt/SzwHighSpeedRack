namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseProductMaterialMap : IEntityTypeConfiguration<BaseProductMaterial>
    {
        public void Configure(EntityTypeBuilder<BaseProductMaterial> builder)
        {
            builder.ToTable("BaseProductMaterial").HasKey(x => x.Id);
        }
    }
}