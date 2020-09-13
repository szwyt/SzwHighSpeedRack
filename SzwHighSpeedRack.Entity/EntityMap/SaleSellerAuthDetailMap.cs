namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleSellerAuthDetailMap : IEntityTypeConfiguration<SaleSellerAuthDetail>
    {
        public void Configure(EntityTypeBuilder<SaleSellerAuthDetail> builder)
        {
            builder.ToTable("SaleSellerAuthDetail").HasKey(x => x.Id);
        }
    }
}



