namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseTemplateMap : IEntityTypeConfiguration<BaseTemplate>
    {
        public void Configure(EntityTypeBuilder<BaseTemplate> builder)
        {
            builder.ToTable("BaseTemplate").HasKey(x => x.Id);
        }
    }
}



