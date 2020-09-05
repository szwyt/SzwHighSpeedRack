using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SzwHighSpeedRack.Test.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContentTitle = table.Column<string>(maxLength: 50, nullable: false),
                    ModelId = table.Column<int>(nullable: true),
                    HasModelContent = table.Column<int>(nullable: false),
                    ParId = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteCategory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteCategory");
        }
    }
}
