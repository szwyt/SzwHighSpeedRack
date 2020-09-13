namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteModelColumnMap : IEntityTypeConfiguration<SiteModelColumn>
    {
        public void Configure(EntityTypeBuilder<SiteModelColumn> builder)
        {
            builder.ToTable("SiteModelColumn").HasKey(x => x.Id);
        }
    }
}



