namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdProductMap : IEntityTypeConfiguration<PdProduct>
    {
        public void Configure(EntityTypeBuilder<PdProduct> builder)
        {
            builder.ToTable("PdProduct").HasKey(x => x.Id);
        }
    }
}



