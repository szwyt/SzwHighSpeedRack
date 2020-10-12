namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngRolePermissionMap : IEntityTypeConfiguration<MngRolePermission>
    {
        public void Configure(EntityTypeBuilder<MngRolePermission> builder)
        {
            builder.ToTable("MngRolePermission").HasKey(x => x.Id);
        }
    }
}