namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngAdminMap : IEntityTypeConfiguration<MngAdmin>
    {
        public void Configure(EntityTypeBuilder<MngAdmin> builder)
        {
            builder.ToTable("MngAdmin").HasKey(x => x.Id);
        }
    }
}