namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdBatCodeMap : IEntityTypeConfiguration<PdBatCode>
    {
        public void Configure(EntityTypeBuilder<PdBatCode> builder)
        {
            builder.ToTable("PdBatCode").HasKey(x => x.Id);
        }
    }
}



