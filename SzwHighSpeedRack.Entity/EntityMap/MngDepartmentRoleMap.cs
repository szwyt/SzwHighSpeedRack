namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngDepartmentRoleMap : IEntityTypeConfiguration<MngDepartmentRole>
    {
        public void Configure(EntityTypeBuilder<MngDepartmentRole> builder)
        {
            builder.ToTable("MngDepartmentRole").HasKey(x => x.Id);
        }
    }
}



