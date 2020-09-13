namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseSpecificationsMap : IEntityTypeConfiguration<BaseSpecifications>
    {
        public void Configure(EntityTypeBuilder<BaseSpecifications> builder)
        {
            builder.ToTable("BaseSpecifications").HasKey(x => x.Id);
        }
    }
}



