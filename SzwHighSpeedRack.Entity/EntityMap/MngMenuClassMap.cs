namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngMenuClassMap : IEntityTypeConfiguration<MngMenuClass>
    {
        public void Configure(EntityTypeBuilder<MngMenuClass> builder)
        {
            builder.ToTable("MngMenuClass").HasKey(x => x.Id);
        }
    }
}



