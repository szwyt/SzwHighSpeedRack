namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQualityMap : IEntityTypeConfiguration<PdQuality>
    {
        public void Configure(EntityTypeBuilder<PdQuality> builder)
        {
            builder.ToTable("PdQuality").HasKey(x => x.Id);
        }
    }
}



