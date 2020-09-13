namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteModelMap : IEntityTypeConfiguration<SiteModel>
    {
        public void Configure(EntityTypeBuilder<SiteModel> builder)
        {
            builder.ToTable("SiteModel").HasKey(x => x.Id);
        }
    }
}



