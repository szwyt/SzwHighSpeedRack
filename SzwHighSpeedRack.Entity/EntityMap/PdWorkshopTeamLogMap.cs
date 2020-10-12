namespace SzwHighSpeedRack.Entity
{
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