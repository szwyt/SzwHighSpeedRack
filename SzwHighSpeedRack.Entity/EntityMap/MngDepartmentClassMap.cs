namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngDepartmentClassMap : IEntityTypeConfiguration<MngDepartmentClass>
    {
        public void Configure(EntityTypeBuilder<MngDepartmentClass> builder)
        {
            builder.ToTable("MngDepartmentClass").HasKey(x => x.Id);
        }
    }
}