namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleSellerAuthDetailForSalesMap : IEntityTypeConfiguration<SaleSellerAuthDetailForSales>
    {
        public void Configure(EntityTypeBuilder<SaleSellerAuthDetailForSales> builder)
        {
            builder.ToTable("SaleSellerAuthDetailForSales").HasKey(x => x.Id);
        }
    }
}



