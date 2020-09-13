namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQualitySmeltFinalMap : IEntityTypeConfiguration<PdQualitySmeltFinal>
    {
        public void Configure(EntityTypeBuilder<PdQualitySmeltFinal> builder)
        {
            builder.ToTable("PdQualitySmeltFinal").HasKey(x => x.Id);
        }
    }
}



