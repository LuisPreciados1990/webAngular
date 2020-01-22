using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSystem.Migrations
{
    public partial class producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DP03A110",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pc_ncta = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Pc_ncta2 = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Pc_ncta3 = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    No_parte = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Codinter = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: true, defaultValue: ""),
                    Presentacion2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Aplica = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    Codbarra = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Tipo = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "N"),
                    Modelo = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Proveedor = table.Column<string>(type: "char(6)", nullable: true),
                    Clase = table.Column<string>(type: "char(6)", nullable: true),
                    Subclase = table.Column<string>(type: "char(6)", nullable: true),
                    Origen = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Desunidad = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Factor = table.Column<decimal>(type: "decimal(6, 0)", nullable: false, defaultValue: 1m),
                    Desfactor = table.Column<string>(type: "char(10)", nullable: true),
                    Ubica = table.Column<string>(type: "char(10)", nullable: true),
                    Vstock = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "S"),
                    Iva_sn = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "S"),
                    Exmin = table.Column<decimal>(type: "decimal(12, 3)", nullable: false),
                    Exmax = table.Column<decimal>(type: "decimal(12, 3)", nullable: false),
                    V_ultcom = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    F_ultcom = table.Column<DateTime>(type: "datetime", nullable: false),
                    V_ultven = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    F_ultven = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pvpc1 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Pvpc2 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Pvpc3 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Pvpc4 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Pvpu1 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Pvpu2 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Desunidad2 = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Hasta2 = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Pvpu3 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Desunidad3 = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Hasta3 = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Pvpu4 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Desunidad4 = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Hasta4 = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Pvpu5 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Desunidad5 = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Hasta5 = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Pvpc5 = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Pesocaja = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Modipvp = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Modidescri = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Pordes = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    Comenta = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Estado = table.Column<string>(type: "char(1)", nullable: true, defaultValue: "A"),
                    Cubicau = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Cubicac = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Color = table.Column<string>(type: "char(3)", nullable: true),
                    Talla = table.Column<string>(type: "char(3)", nullable: true),
                    Lasting = table.Column<string>(type: "char(10)", nullable: true),
                    Cantini = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    Costini = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Ultcompra = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    Costo_alor = table.Column<decimal>(type: "decimal(16, 4)", nullable: false),
                    C_ultcom = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Cantini2 = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    Fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_modi = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ult_prv = table.Column<string>(type: "char(6)", nullable: true),
                    Fecha_ve1 = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_ve2 = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pideser = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Es_precio = table.Column<bool>(type: "bit", nullable: false),
                    Imagen2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Motor = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Anio = table.Column<string>(type: "char(4)", nullable: true),
                    Acceso = table.Column<string>(type: "nvarchar(180)", nullable: true),
                    Kmt = table.Column<int>(type: "int", nullable: false),
                    Chasis = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Tipopr = table.Column<string>(type: "char(2)", nullable: true),
                    Vstock2 = table.Column<string>(type: "char(1)", nullable: true),
                    Calidad = table.Column<string>(type: "char(1)", nullable: true),
                    Congelacion = table.Column<string>(type: "char(1)", nullable: true),
                    Corte = table.Column<string>(type: "char(2)", nullable: true),
                    Tip_peso = table.Column<string>(type: "char(1)", nullable: true),
                    Peso = table.Column<string>(type: "char(2)", nullable: true),
                    Empaque = table.Column<string>(type: "char(1)", nullable: true),
                    Presentacion = table.Column<string>(type: "char(2)", nullable: true),
                    Master = table.Column<decimal>(type: "decimal(16, 6)", nullable: false),
                    Claint = table.Column<string>(type: "char(10)", nullable: true),
                    Pesobruto = table.Column<decimal>(type: "decimal(16, 6)", nullable: false),
                    Codcomp = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Codvent = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    F_aju = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tp_items = table.Column<string>(type: "char(3)", nullable: true),
                    TieICE = table.Column<string>(type: "char(1)", nullable: true),
                    Porcomia = table.Column<decimal>(type: "numeric (6, 2)", nullable: false),
                    Porcomib = table.Column<decimal>(type: "numeric (6, 2)", nullable: false),
                    Meses = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Subclase2 = table.Column<string>(type: "char(6)", nullable: true),
                    P2 = table.Column<string>(type: "char(10)", nullable: true),
                    P3 = table.Column<string>(type: "char(10)", nullable: true),
                    Rcanti1 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcantf1 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcanti2 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcantf2 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcanti3 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcantf3 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcanti4 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcantf4 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcanti5 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Rcantf5 = table.Column<decimal>(type: "decimal(18, 6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DP03A110", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DP05A110_Empcli",
                table: "DP05A110",
                column: "Empcli");

            migrationBuilder.CreateIndex(
                name: "IX_DP03A110_No_parte",
                table: "DP03A110",
                column: "No_parte");

            migrationBuilder.CreateIndex(
                name: "IX_DP03A110_Nombre",
                table: "DP03A110",
                column: "Nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DP03A110");

            migrationBuilder.DropIndex(
                name: "IX_DP05A110_Empcli",
                table: "DP05A110");
        }
    }
}
