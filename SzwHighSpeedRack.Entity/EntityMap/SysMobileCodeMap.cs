namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SysMobileCodeMap : IEntityTypeConfiguration<SysMobileCode>
    {
        public void Configure(EntityTypeBuilder<SysMobileCode> builder)
        {
            builder.ToTable("SysMobileCode").HasKey(x => x.Id);
        }
    }
}



