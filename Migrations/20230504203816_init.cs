using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrpcAgroService.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgroFields",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Aria = table.Column<int>(type: "int", nullable: false),
                    Bal = table.Column<int>(type: "int", nullable: false),
                    PH = table.Column<int>(type: "int", nullable: false),
                    Gumus = table.Column<int>(type: "int", nullable: false),
                    Azot = table.Column<int>(type: "int", nullable: false),
                    Phosfor = table.Column<int>(type: "int", nullable: false),
                    Kaliy = table.Column<int>(type: "int", nullable: false),
                    Manganese = table.Column<int>(type: "int", nullable: false),
                    Cobalt = table.Column<int>(type: "int", nullable: false),
                    Copper = table.Column<int>(type: "int", nullable: false),
                    Zinc = table.Column<int>(type: "int", nullable: false),
                    Lead = table.Column<int>(type: "int", nullable: false),
                    Cesium = table.Column<int>(type: "int", nullable: false),
                    Strontium = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgroFields", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgroFields");
        }
    }
}
