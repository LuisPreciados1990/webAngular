using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSystem.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebGestiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    NombreCorto = table.Column<string>(nullable: true),
                    Namebmp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebGestiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebProgramas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GesApl = table.Column<string>(nullable: true),
                    Tarea = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    Opciones = table.Column<string>(nullable: true),
                    Orden = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProgramas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    UserLog = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebUsuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebGestiones");

            migrationBuilder.DropTable(
                name: "WebProgramas");

            migrationBuilder.DropTable(
                name: "WebUsuarios");
        }
    }
}
