namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SitelinkMap : IEntityTypeConfiguration<Sitelink>
    {
        public void Configure(EntityTypeBuilder<Sitelink> builder)
        {
            builder.ToTable("Sitelink").HasKey(x => x.Id);
        }
    }
}



