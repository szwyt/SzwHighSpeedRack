namespace SzwHighSpeedRack.Entity
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MngAdminMap : IEntityTypeConfiguration<MngAdmin>
    {
        public void Configure(EntityTypeBuilder<MngAdmin> builder)
        {
            builder.ToTable("MngAdmin").HasKey(x => x.Id);

            builder.Property(x => x.GroupManage).HasColumnType("json")
                 .HasConversion(v => JsonConvert.SerializeObject(v,
                                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                                   v => JsonConvert.DeserializeObject<List<int>>(v,
                                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                .UseJsonChangeTrackingOptions(MySqlCommonJsonChangeTrackingOptions.RootPropertyOnly);
            builder.Property(x => x.MobilePhone).HasColumnType("json")
                .HasConversion(v => JsonConvert.SerializeObject(v,
                                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                                   v => JsonConvert.DeserializeObject<List<string>>(v,
                                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                .UseJsonChangeTrackingOptions(MySqlCommonJsonChangeTrackingOptions.RootPropertyOnly);
        }
    }
}