namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SiteSinglePageMap : IEntityTypeConfiguration<SiteSinglePage>
    {
        public void Configure(EntityTypeBuilder<SiteSinglePage> builder)
        {
            builder.ToTable("SiteSinglePage").HasKey(x => x.Id);
        }
    }
}



