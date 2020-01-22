using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSystem.Migrations
{
    public partial class alptabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlpTabla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Master = table.Column<string>(type: "char(5)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    Nomtag = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValue: ""),
                    Gestion = table.Column<string>(type: "char(3)", nullable: true, defaultValue: ""),
                    Pideval = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Campo1 = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Grupo = table.Column<string>(type: "nvarchar(70)", nullable: true, defaultValue: ""),
                    Sgrupo = table.Column<string>(type: "nvarchar(70)", nullable: true, defaultValue: ""),
                    Campo2 = table.Column<string>(type: "nvarchar(30)", nullable: true, defaultValue: ""),
                    Lencod = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Valor2 = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlpTabla", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlpTabla_Codigo",
                table: "AlpTabla",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_AlpTabla_Master",
                table: "AlpTabla",
                column: "Master");

            migrationBuilder.CreateIndex(
                name: "IX_AlpTabla_Nomtag",
                table: "AlpTabla",
                column: "Nomtag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlpTabla");
        }
    }
}
