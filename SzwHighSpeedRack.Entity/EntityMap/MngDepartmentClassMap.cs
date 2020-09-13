namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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



