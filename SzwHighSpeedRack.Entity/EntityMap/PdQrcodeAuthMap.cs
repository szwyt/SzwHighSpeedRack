namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQrcodeAuthMap : IEntityTypeConfiguration<PdQrcodeAuth>
    {
        public void Configure(EntityTypeBuilder<PdQrcodeAuth> builder)
        {
            builder.ToTable("PdQrcodeAuth").HasKey(x => x.Id);
        }
    }
}