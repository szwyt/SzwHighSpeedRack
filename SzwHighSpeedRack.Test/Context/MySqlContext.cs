using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SzwHighSpeedRack.Test.Entity;

namespace SzwHighSpeedRack.Test.Context
{
    public partial class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseBrand> BaseBrand { get; set; }
        public virtual DbSet<BaseGbProduction> BaseGbProduction { get; set; }
        public virtual DbSet<BaseProductClass> BaseProductClass { get; set; }
        public virtual DbSet<BaseProductGbClass> BaseProductGbClass { get; set; }
        public virtual DbSet<BaseProductMaterial> BaseProductMaterial { get; set; }
        public virtual DbSet<BaseQualityStandard> BaseQualityStandard { get; set; }
        public virtual DbSet<BaseSpecifications> BaseSpecifications { get; set; }
        public virtual DbSet<BaseTemplate> BaseTemplate { get; set; }
        public virtual DbSet<MngAdmin> MngAdmin { get; set; }
        public virtual DbSet<MngDepartmentClass> MngDepartmentClass { get; set; }
        public virtual DbSet<MngDepartmentRole> MngDepartmentRole { get; set; }
        public virtual DbSet<MngDepartmentWorkshopRoleAdmin> MngDepartmentWorkshopRoleAdmin { get; set; }
        public virtual DbSet<MngLoginLog> MngLoginLog { get; set; }
        public virtual DbSet<MngMenuClass> MngMenuClass { get; set; }
        public virtual DbSet<MngRole> MngRole { get; set; }
        public virtual DbSet<MngRoleAdmin> MngRoleAdmin { get; set; }
        public virtual DbSet<MngRolePermission> MngRolePermission { get; set; }
        public virtual DbSet<MngSetting> MngSetting { get; set; }
        public virtual DbSet<MngSystemInfo> MngSystemInfo { get; set; }
        public virtual DbSet<MngSystemSetting> MngSystemSetting { get; set; }
        public virtual DbSet<PdBatCode> PdBatCode { get; set; }
        public virtual DbSet<PdProduct> PdProduct { get; set; }
        public virtual DbSet<PdQrcodeAuth> PdQrcodeAuth { get; set; }
        public virtual DbSet<PdQrcodePrintedLog> PdQrcodePrintedLog { get; set; }
        public virtual DbSet<PdQuality> PdQuality { get; set; }
        public virtual DbSet<PdQualityHighCode> PdQualityHighCode { get; set; }
        public virtual DbSet<PdQualityProductPreset> PdQualityProductPreset { get; set; }
        public virtual DbSet<PdQualitySmeltCode> PdQualitySmeltCode { get; set; }
        public virtual DbSet<PdQualitySmeltFinal> PdQualitySmeltFinal { get; set; }
        public virtual DbSet<PdStockOut> PdStockOut { get; set; }
        public virtual DbSet<PdStockOutDetail> PdStockOutDetail { get; set; }
        public virtual DbSet<PdWorkshop> PdWorkshop { get; set; }
        public virtual DbSet<PdWorkshopTeam> PdWorkshopTeam { get; set; }
        public virtual DbSet<PdWorkshopTeamLog> PdWorkshopTeamLog { get; set; }
        public virtual DbSet<SalePrintLog> SalePrintLog { get; set; }
        public virtual DbSet<SalePrintLogDetail> SalePrintLogDetail { get; set; }
        public virtual DbSet<SaleSeller> SaleSeller { get; set; }
        public virtual DbSet<SaleSellerAuth> SaleSellerAuth { get; set; }
        public virtual DbSet<SaleSellerAuthDetail> SaleSellerAuthDetail { get; set; }
        public virtual DbSet<SaleSellerAuthDetailForSales> SaleSellerAuthDetailForSales { get; set; }
        public virtual DbSet<SaleSellerAuthForSales> SaleSellerAuthForSales { get; set; }
        public virtual DbSet<SiteBasic> SiteBasic { get; set; }
        public virtual DbSet<SiteCategory> SiteCategory { get; set; }
        public virtual DbSet<SiteModel> SiteModel { get; set; }
        public virtual DbSet<SiteModelColumn> SiteModelColumn { get; set; }
        public virtual DbSet<SiteSinglePage> SiteSinglePage { get; set; }
        public virtual DbSet<Sitelink> Sitelink { get; set; }
        public virtual DbSet<SysMobileCode> SysMobileCode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NFineBase;Integrated Security=True");
            }
        }

        /// <summary>
        /// modelBuilder.
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SzwHighSpeedRack.Test.dll"));
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
