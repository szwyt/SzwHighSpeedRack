namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngDepartmentWorkshopRoleAdminMap : IEntityTypeConfiguration<MngDepartmentWorkshopRoleAdmin>
    {
        public void Configure(EntityTypeBuilder<MngDepartmentWorkshopRoleAdmin> builder)
        {
            builder.ToTable("MngDepartmentWorkshopRoleAdmin").HasKey(x => x.Id);
        }
    }
}



