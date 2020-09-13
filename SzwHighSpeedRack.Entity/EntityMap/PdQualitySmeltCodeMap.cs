namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdQualitySmeltCodeMap : IEntityTypeConfiguration<PdQualitySmeltCode>
    {
        public void Configure(EntityTypeBuilder<PdQualitySmeltCode> builder)
        {
            builder.ToTable("PdQualitySmeltCode").HasKey(x => x.Id);
        }
    }
}



