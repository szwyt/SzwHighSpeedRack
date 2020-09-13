namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PdWorkshopTeamMap : IEntityTypeConfiguration<PdWorkshopTeam>
    {
        public void Configure(EntityTypeBuilder<PdWorkshopTeam> builder)
        {
            builder.ToTable("PdWorkshopTeam").HasKey(x => x.Id);
        }
    }
}



