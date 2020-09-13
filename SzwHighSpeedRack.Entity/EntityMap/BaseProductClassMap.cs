namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseProductClassMap : IEntityTypeConfiguration<BaseProductClass>
    {
        public void Configure(EntityTypeBuilder<BaseProductClass> builder)
        {
            builder.ToTable("BaseProductClass").HasKey(x => x.Id);
        }
    }
}



