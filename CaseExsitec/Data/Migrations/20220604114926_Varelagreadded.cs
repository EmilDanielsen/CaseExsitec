using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseExsitec.Data.Migrations
{
    public partial class Varelagreadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Varelagre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lagernr = table.Column<int>(type: "int", nullable: false),
                    Sted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varelagre", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Varelagre");
        }
    }
}
