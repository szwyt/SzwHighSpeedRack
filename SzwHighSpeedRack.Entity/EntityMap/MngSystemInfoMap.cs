namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MngSystemInfoMap : IEntityTypeConfiguration<MngSystemInfo>
    {
        public void Configure(EntityTypeBuilder<MngSystemInfo> builder)
        {
            builder.ToTable("MngSystemInfo").HasKey(x => x.Id);
        }
    }
}



