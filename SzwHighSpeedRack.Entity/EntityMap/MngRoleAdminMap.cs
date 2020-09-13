namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngRoleAdminMap : IEntityTypeConfiguration<MngRoleAdmin>
    {
        public void Configure(EntityTypeBuilder<MngRoleAdmin> builder)
        {
            builder.ToTable("MngRoleAdmin").HasKey(x => x.Id);
        }
    }
}



