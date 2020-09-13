namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdStockOutDetailMap : IEntityTypeConfiguration<PdStockOutDetail>
    {
        public void Configure(EntityTypeBuilder<PdStockOutDetail> builder)
        {
            builder.ToTable("PdStockOutDetail").HasKey(x => x.Id);
        }
    }
}



