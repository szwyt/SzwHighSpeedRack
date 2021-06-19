using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SzwHighSpeedRack.Entity;

namespace SzwHighSpeedRack.Entity.EntityMap
{
    public class SysMobileCodeMap : IEntityTypeConfiguration<YFSYS_MENU>
    {
        public void Configure(EntityTypeBuilder<YFSYS_MENU> builder)
        {
            builder.ToTable("YFSYS_MENU").HasKey(x => x.Id).HasName("ID");
            //指定需要关联的序列名称
            builder.Property(e => e.Id).UseHiLo("YFSYS_MENU_S");
        }
    }
}