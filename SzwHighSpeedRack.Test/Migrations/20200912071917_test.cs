using Microsoft.EntityFrameworkCore.Migrations;

namespace SzwHighSpeedRack.Test.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseGbProduction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseGbProduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseProductClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gbname = table.Column<string>(nullable: true),
                    DeliveryType = table.Column<int>(nullable: true),
                    Measurement = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProductClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseProductGbClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GbName = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProductGbClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseProductMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StandardStrength = table.Column<int>(nullable: true),
                    AntiEarthquake = table.Column<short>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    TemplateName = table.Column<string>(nullable: true),
                    IsCancel = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProductMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseQualityStandard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    StandardId = table.Column<int>(nullable: false),
                    TargetName = table.Column<string>(nullable: true),
                    TargetNameEn = table.Column<string>(nullable: true),
                    TargetMin = table.Column<double>(nullable: true),
                    TargetMax = table.Column<double>(nullable: true),
                    TargetMinInner = table.Column<double>(nullable: true),
                    TargetMaxInner = table.Column<double>(nullable: true),
                    TargetNote = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    TargetCategory = table.Column<int>(nullable: true),
                    SampleType = table.Column<int>(nullable: true),
                    IsRequired = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseQualityStandard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SpecName = table.Column<string>(nullable: true),
                    CallName = table.Column<string>(nullable: true),
                    ReferLength = table.Column<double>(nullable: true),
                    ReferMeterWeight = table.Column<double>(nullable: true),
                    ReferPieceCount = table.Column<double>(nullable: true),
                    ReferPieceWeight = table.Column<double>(nullable: true),
                    ColdRatio = table.Column<double>(nullable: true),
                    ReverseRatio = table.Column<double>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    ApplyNumber = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    FirstChar = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Qq = table.Column<string>(nullable: true),
                    InJob = table.Column<short>(nullable: true),
                    IsCanDelete = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngDepartmentClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: true),
                    ChildNum = table.Column<int>(nullable: true),
                    Depth = table.Column<int>(nullable: true),
                    ParId = table.Column<int>(nullable: true),
                    ParPath = table.Column<string>(nullable: true),
                    IsBeLock = table.Column<short>(nullable: true),
                    IsCanDelete = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngDepartmentClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngDepartmentRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngDepartmentRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngDepartmentWorkshopRoleAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: false),
                    IsDeny = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngDepartmentWorkshopRoleAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngLoginLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginTime = table.Column<int>(nullable: true),
                    LoginIp = table.Column<string>(nullable: true),
                    LoginUserId = table.Column<int>(nullable: false),
                    LoginUserName = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngLoginLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngMenuClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParId = table.Column<int>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    ClassNameEn = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Depth = table.Column<int>(nullable: true),
                    ChildNum = table.Column<int>(nullable: true),
                    ParPath = table.Column<string>(nullable: true),
                    PlatformType = table.Column<int>(nullable: true),
                    PermissionType = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    TargetType = table.Column<int>(nullable: true),
                    IsHideInMenu = table.Column<short>(nullable: true),
                    IsCanDelete = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngMenuClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true),
                    GroupNameEn = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsLock = table.Column<short>(nullable: true),
                    IsCanDelete = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngRoleAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngRoleAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngRolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    IsDeny = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngRolePermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apiroot = table.Column<string>(nullable: true),
                    BatCodeRule = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    ClientEn = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    DomainPc = table.Column<string>(nullable: true),
                    DomainWap = table.Column<string>(nullable: true),
                    DomainWebApi = table.Column<string>(nullable: true),
                    DomainQrcode = table.Column<string>(nullable: true),
                    DomainCertImg = table.Column<string>(nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressEn = table.Column<string>(nullable: true),
                    PermitNo = table.Column<string>(nullable: true),
                    SjbadvertiseId = table.Column<int>(nullable: false),
                    Sjbsmscode = table.Column<string>(nullable: true),
                    SjbsmstypeId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<string>(nullable: true),
                    SystemVersion = table.Column<int>(nullable: true),
                    SecretKey = table.Column<string>(nullable: true),
                    ProductRegistrationNumber = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    HandoverTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngSystemInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(nullable: true),
                    ClientEn = table.Column<string>(nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    SecretKey = table.Column<string>(nullable: true),
                    ProductRegistrationNumber = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngSystemInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MngSystemSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingCode = table.Column<string>(nullable: true),
                    SettingName = table.Column<string>(nullable: true),
                    SettingValue = table.Column<string>(nullable: true),
                    ValueType = table.Column<int>(nullable: true),
                    ValueLength = table.Column<int>(nullable: true),
                    SettingDesc = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MngSystemSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdBatCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatCode = table.Column<string>(nullable: true),
                    SerialNo = table.Column<int>(nullable: true),
                    WorkshopId = table.Column<int>(nullable: false),
                    BilletNumber = table.Column<int>(nullable: true),
                    BilletPieceWeight = table.Column<double>(nullable: true),
                    ProductRate = table.Column<double>(nullable: true),
                    ShiftId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdBatCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatCode = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    BundleCode = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    LengthType = table.Column<int>(nullable: true),
                    MeterWeight = table.Column<double>(nullable: true),
                    PieceCount = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    RandomCode = table.Column<string>(nullable: true),
                    Adder = table.Column<string>(nullable: true),
                    ProductDate = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    IsCancelled = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQrcodeAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    AuthDate = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQrcodeAuth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQrcodePrintedLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQrcodePrintedLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQuality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatCode = table.Column<string>(nullable: true),
                    QualityInfos = table.Column<string>(nullable: true),
                    QualityInfosDynamics = table.Column<string>(nullable: true),
                    WorkshopId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SmeltId = table.Column<int>(nullable: false),
                    IsPreset = table.Column<int>(nullable: true),
                    EntryPerson = table.Column<string>(nullable: true),
                    CheckPerson = table.Column<string>(nullable: true),
                    CheckNote = table.Column<string>(nullable: true),
                    CheckStatus = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQuality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQualityHighCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighCode = table.Column<string>(nullable: true),
                    Quality = table.Column<string>(nullable: true),
                    MaterialId = table.Column<int>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    EntryPerson = table.Column<string>(nullable: true),
                    LastUpdatetime = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQualityHighCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQualityProductPreset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatCode = table.Column<string>(nullable: true),
                    MaterialId = table.Column<int>(nullable: false),
                    QualityId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQualityProductPreset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQualitySmeltCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmeltCode = table.Column<string>(nullable: true),
                    Quality = table.Column<string>(nullable: true),
                    MaterialId = table.Column<int>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false),
                    EntryPerson = table.Column<string>(nullable: true),
                    LastUpdatetime = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQualitySmeltCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdQualitySmeltFinal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmeltCode = table.Column<string>(nullable: true),
                    Quality = table.Column<string>(nullable: true),
                    MaterialId = table.Column<int>(nullable: false),
                    EntryPerson = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdQualitySmeltFinal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdStockOut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(nullable: false),
                    Consignor = table.Column<string>(nullable: true),
                    Lpn = table.Column<string>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DriverIdCard = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    PrintTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdStockOut", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdStockOutDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    StockOutId = table.Column<int>(nullable: false),
                    BatCode = table.Column<string>(nullable: true),
                    MaterialName = table.Column<string>(nullable: true),
                    SpecName = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdStockOutDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdWorkshop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdWorkshop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdWorkshopTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Leader = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdWorkshopTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdWorkshopTeamLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatCode = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdWorkshopTeamLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalePrintLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consignor = table.Column<string>(nullable: true),
                    PrintNo = table.Column<string>(nullable: true),
                    SignetAngle = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    CheckCode = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePrintLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalePrintLogDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintId = table.Column<int>(nullable: false),
                    AuthId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: true),
                    PrintNumber = table.Column<int>(nullable: true),
                    BuildType = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePrintLogDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSeller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Parent = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSeller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSellerAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(nullable: false),
                    StockOutId = table.Column<int>(nullable: false),
                    BatCode = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false),
                    LengthType = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: true),
                    ParentSellerId = table.Column<int>(nullable: false),
                    ParentAuthId = table.Column<int>(nullable: true),
                    Lpn = table.Column<string>(nullable: true),
                    AuthTime = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSellerAuth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSellerAuthDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    MaterialName = table.Column<string>(nullable: true),
                    SpecName = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    BatCode = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSellerAuthDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSellerAuthDetailForSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    MaterialName = table.Column<string>(nullable: true),
                    SpecName = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    BatCode = table.Column<string>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    DataSourceType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSellerAuthDetailForSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSellerAuthForSales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(nullable: false),
                    StockOutId = table.Column<int>(nullable: false),
                    BatCode = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    SpecId = table.Column<int>(nullable: false),
                    LengthType = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: true),
                    ParentSellerId = table.Column<int>(nullable: false),
                    ParentAuthId = table.Column<int>(nullable: true),
                    Lpn = table.Column<string>(nullable: true),
                    AuthTime = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false),
                    DataSourceType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSellerAuthForSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteBasic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteTitle = table.Column<string>(nullable: true),
                    SiteTitleEn = table.Column<string>(nullable: true),
                    CompAddress = table.Column<string>(nullable: true),
                    SiteDesc = table.Column<string>(nullable: true),
                    CarouselImage = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    LogoText = table.Column<string>(nullable: true),
                    Icp = table.Column<string>(nullable: true),
                    Copyright = table.Column<string>(nullable: true),
                    StatsCode = table.Column<string>(nullable: true),
                    CompName = table.Column<string>(nullable: true),
                    MapLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteBasic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTitle = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    HasModelContent = table.Column<int>(nullable: true),
                    ParId = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    Depth = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sitelink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PicLink = table.Column<string>(nullable: true),
                    PicWidth = table.Column<int>(nullable: true),
                    PicHeight = table.Column<int>(nullable: true),
                    IsShow = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true),
                    LinkType = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitelink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseManageId = table.Column<string>(nullable: true),
                    CheckStatusManageModel = table.Column<int>(nullable: false),
                    CreateTime = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Uid = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteModelColumn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FildDescription = table.Column<string>(nullable: true),
                    FildIsNull = table.Column<int>(nullable: true),
                    FildLength = table.Column<int>(nullable: true),
                    FildName = table.Column<string>(nullable: true),
                    FildType = table.Column<int>(nullable: false),
                    PageShowType = table.Column<int>(nullable: false),
                    FildValue = table.Column<string>(nullable: true),
                    FildWeight = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteModelColumn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSinglePage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    ReleaseTime = table.Column<int>(nullable: true),
                    Descrption = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: true),
                    CreateUserName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSinglePage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMobileCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    CodeType = table.Column<int>(nullable: false),
                    IsValaid = table.Column<short>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    SendTime = table.Column<int>(nullable: true),
                    CreateTime = table.Column<int>(nullable: true),
                    CreateUserId = table.Column<int>(nullable: false),
                    CreateUserName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMobileCode", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseBrand");

            migrationBuilder.DropTable(
                name: "BaseGbProduction");

            migrationBuilder.DropTable(
                name: "BaseProductClass");

            migrationBuilder.DropTable(
                name: "BaseProductGbClass");

            migrationBuilder.DropTable(
                name: "BaseProductMaterial");

            migrationBuilder.DropTable(
                name: "BaseQualityStandard");

            migrationBuilder.DropTable(
                name: "BaseSpecifications");

            migrationBuilder.DropTable(
                name: "BaseTemplate");

            migrationBuilder.DropTable(
                name: "MngAdmin");

            migrationBuilder.DropTable(
                name: "MngDepartmentClass");

            migrationBuilder.DropTable(
                name: "MngDepartmentRole");

            migrationBuilder.DropTable(
                name: "MngDepartmentWorkshopRoleAdmin");

            migrationBuilder.DropTable(
                name: "MngLoginLog");

            migrationBuilder.DropTable(
                name: "MngMenuClass");

            migrationBuilder.DropTable(
                name: "MngRole");

            migrationBuilder.DropTable(
                name: "MngRoleAdmin");

            migrationBuilder.DropTable(
                name: "MngRolePermission");

            migrationBuilder.DropTable(
                name: "MngSetting");

            migrationBuilder.DropTable(
                name: "MngSystemInfo");

            migrationBuilder.DropTable(
                name: "MngSystemSetting");

            migrationBuilder.DropTable(
                name: "PdBatCode");

            migrationBuilder.DropTable(
                name: "PdProduct");

            migrationBuilder.DropTable(
                name: "PdQrcodeAuth");

            migrationBuilder.DropTable(
                name: "PdQrcodePrintedLog");

            migrationBuilder.DropTable(
                name: "PdQuality");

            migrationBuilder.DropTable(
                name: "PdQualityHighCode");

            migrationBuilder.DropTable(
                name: "PdQualityProductPreset");

            migrationBuilder.DropTable(
                name: "PdQualitySmeltCode");

            migrationBuilder.DropTable(
                name: "PdQualitySmeltFinal");

            migrationBuilder.DropTable(
                name: "PdStockOut");

            migrationBuilder.DropTable(
                name: "PdStockOutDetail");

            migrationBuilder.DropTable(
                name: "PdWorkshop");

            migrationBuilder.DropTable(
                name: "PdWorkshopTeam");

            migrationBuilder.DropTable(
                name: "PdWorkshopTeamLog");

            migrationBuilder.DropTable(
                name: "SalePrintLog");

            migrationBuilder.DropTable(
                name: "SalePrintLogDetail");

            migrationBuilder.DropTable(
                name: "SaleSeller");

            migrationBuilder.DropTable(
                name: "SaleSellerAuth");

            migrationBuilder.DropTable(
                name: "SaleSellerAuthDetail");

            migrationBuilder.DropTable(
                name: "SaleSellerAuthDetailForSales");

            migrationBuilder.DropTable(
                name: "SaleSellerAuthForSales");

            migrationBuilder.DropTable(
                name: "SiteBasic");

            migrationBuilder.DropTable(
                name: "SiteCategory");

            migrationBuilder.DropTable(
                name: "Sitelink");

            migrationBuilder.DropTable(
                name: "SiteModel");

            migrationBuilder.DropTable(
                name: "SiteModelColumn");

            migrationBuilder.DropTable(
                name: "SiteSinglePage");

            migrationBuilder.DropTable(
                name: "SysMobileCode");
        }
    }
}