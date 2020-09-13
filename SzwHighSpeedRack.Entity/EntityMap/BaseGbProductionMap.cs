namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseGbProductionMap : IEntityTypeConfiguration<BaseGbProduction>
    {
        public void Configure(EntityTypeBuilder<BaseGbProduction> builder)
        {
            builder.ToTable("BaseGbProduction").HasKey(x => x.Id);
        }
    }
}



