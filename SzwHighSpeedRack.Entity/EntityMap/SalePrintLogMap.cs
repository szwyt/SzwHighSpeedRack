namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalePrintLogMap : IEntityTypeConfiguration<SalePrintLog>
    {
        public void Configure(EntityTypeBuilder<SalePrintLog> builder)
        {
            builder.ToTable("SalePrintLog").HasKey(x => x.Id);
        }
    }
}



