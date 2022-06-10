using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dCandidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    bloodGroup = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    MyProperty = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dCandidates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dCandidates");
        }
    }
}
