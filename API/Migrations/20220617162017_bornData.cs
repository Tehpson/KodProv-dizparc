using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class bornData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BornStastitics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BornStastitics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegionData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountBornFemale = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountBornMale = table.Column<int>(type: "INTEGER", nullable: false),
                    DataID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegionData_BornStastitics_DataID",
                        column: x => x.DataID,
                        principalTable: "BornStastitics",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionData_DataID",
                table: "RegionData",
                column: "DataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionData");

            migrationBuilder.DropTable(
                name: "BornStastitics");
        }
    }
}
