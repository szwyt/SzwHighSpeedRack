namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngRoleMap : IEntityTypeConfiguration<MngRole>
    {
        public void Configure(EntityTypeBuilder<MngRole> builder)
        {
            builder.ToTable("MngRole").HasKey(x => x.Id);
        }
    }
}