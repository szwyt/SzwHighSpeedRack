namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdWorkshopTeamLogMap : IEntityTypeConfiguration<PdWorkshopTeamLog>
    {
        public void Configure(EntityTypeBuilder<PdWorkshopTeamLog> builder)
        {
            builder.ToTable("PdWorkshopTeamLog").HasKey(x => x.Id);
        }
    }
}



