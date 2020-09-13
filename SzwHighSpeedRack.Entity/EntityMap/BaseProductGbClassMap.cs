namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseProductGbClassMap : IEntityTypeConfiguration<BaseProductGbClass>
    {
        public void Configure(EntityTypeBuilder<BaseProductGbClass> builder)
        {
            builder.ToTable("BaseProductGbClass").HasKey(x => x.Id);
        }
    }
}



