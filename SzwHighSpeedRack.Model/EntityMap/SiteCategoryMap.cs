namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// 表映射.
    /// </summary>
    public class SiteCategoryMap : IEntityTypeConfiguration<SiteCategory>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<SiteCategory> builder)
        {
            builder.ToTable("SiteCategory").HasKey(x => x.Id);
        }
    }
}
