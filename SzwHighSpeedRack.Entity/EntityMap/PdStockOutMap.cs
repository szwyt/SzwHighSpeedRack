namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdStockOutMap : IEntityTypeConfiguration<PdStockOut>
    {
        public void Configure(EntityTypeBuilder<PdStockOut> builder)
        {
            builder.ToTable("PdStockOut").HasKey(x => x.Id);
        }
    }
}



