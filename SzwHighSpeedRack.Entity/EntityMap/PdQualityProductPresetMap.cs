namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQualityProductPresetMap : IEntityTypeConfiguration<PdQualityProductPreset>
    {
        public void Configure(EntityTypeBuilder<PdQualityProductPreset> builder)
        {
            builder.ToTable("PdQualityProductPreset").HasKey(x => x.Id);
        }
    }
}



