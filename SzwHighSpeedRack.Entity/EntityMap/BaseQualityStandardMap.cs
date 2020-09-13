namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseQualityStandardMap : IEntityTypeConfiguration<BaseQualityStandard>
    {
        public void Configure(EntityTypeBuilder<BaseQualityStandard> builder)
        {
            builder.ToTable("BaseQualityStandard").HasKey(x => x.Id);
        }
    }
}



