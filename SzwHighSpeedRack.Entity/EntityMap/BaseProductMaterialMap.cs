namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseProductMaterialMap : IEntityTypeConfiguration<BaseProductMaterial>
    {
        public void Configure(EntityTypeBuilder<BaseProductMaterial> builder)
        {
            builder.ToTable("BaseProductMaterial").HasKey(x => x.Id);
        }
    }
}



