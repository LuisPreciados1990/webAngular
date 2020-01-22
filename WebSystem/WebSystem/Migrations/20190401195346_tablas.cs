using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSystem.Migrations
{
    public partial class tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "DP01A110",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DP03ACOM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "char(2)", nullable: false),
                    Codigo_i = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Codigo_e = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false, defaultValue: ""),
                    Main = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Tipo = table.Column<string>(type: "char(1)", nullable: false, defaultValue: ""),
                    Pidecosto = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Inventario = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "S"),
                    Numero = table.Column<string>(type: "char(8)", nullable: false, defaultValue: "00000000"),
                    Forma = table.Column<string>(type: "char(8)", nullable: true, defaultValue: ""),
                    Forma2 = table.Column<string>(type: "char(8)", nullable: true, defaultValue: ""),
                    Grupo = table.Column<string>(type: "char(1)", nullable: false, defaultValue: ""),
                    Iva = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "S"),
                    Items = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "C"),
                    Ocultaiva = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "N"),
                    Permitedes = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "N"),
                    Tp_credito = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Tp_aplica = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Integra = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Empresa = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Tpintegra = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Generanc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Ptovta = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    V_traspor = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    C_lineas = table.Column<string>(type: "char(1)", nullable: true, defaultValue: "S"),
                    Tp_ret = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Control_it = table.Column<string>(type: "char(1)", nullable: true, defaultValue: "N"),
                    Num_it = table.Column<decimal>(type: "decimal(2, 0)", nullable: false, defaultValue: 0m),
                    Tpnumera = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Od = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Ing_valdes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Rma = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Iva_credi = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Ctaxpagar = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Devol = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Actcto = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Transp = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Tipo2 = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Ajuste = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Fiscal = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Signo = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Rt_manu = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Es_produ = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    At_exporta = table.Column<string>(type: "char(1)", nullable: false, defaultValue: ""),
                    Tiport = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Celectro = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Serie = table.Column<string>(type: "char(6)", nullable: true, defaultValue: ""),
                    Tp_op = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Es_lc = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Cta_provi = table.Column<string>(type: "nvarchar(20)", nullable: true, defaultValue: ""),
                    Tp_ent = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Es_exporta = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Validart = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activa_mod = table.Column<string>(type: "char(3)", nullable: true, defaultValue: ""),
                    Num_descu = table.Column<decimal>(type: "decimal(2, 0)", nullable: false, defaultValue: 0m),
                    PrinterPDF = table.Column<string>(type: "nvarchar(20)", nullable: true, defaultValue: ""),
                    Es_reserva = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AjuSave = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Bode_linea = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Orden = table.Column<decimal>(type: "decimal(5, 0)", nullable: false, defaultValue: 0m),
                    CSaldo = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Tp_deuda = table.Column<string>(type: "char(2)", nullable: true, defaultValue: ""),
                    Con_ctavta = table.Column<string>(type: "nvarchar(20)", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DP03ACOM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DP05A110",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "char(6)", nullable: false),
                    Cod_uees = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValue: ""),
                    Pc_ncta = table.Column<string>(type: "nvarchar(20)", nullable: true, defaultValue: ""),
                    Empcli = table.Column<string>(type: "nvarchar(70)", nullable: false, defaultValue: ""),
                    Nomcli = table.Column<string>(type: "nvarchar(70)", nullable: true, defaultValue: ""),
                    Tipopre = table.Column<string>(type: "char(1)", nullable: true, defaultValue: ""),
                    Ruc = table.Column<string>(type: "nvarchar(13)", nullable: true, defaultValue: ""),
                    Direccion = table.Column<string>(type: "nvarchar(250)", nullable: true, defaultValue: ""),
                    Direccion2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Fono1 = table.Column<string>(type: "char(10)", nullable: true, defaultValue: ""),
                    Fono2 = table.Column<string>(type: "char(10)", nullable: true),
                    Vendedor = table.Column<string>(type: "char(3)", nullable: true, defaultValue: ""),
                    Diasp = table.Column<decimal>(type: "numeric(3, 0)", nullable: false),
                    Fecha_ultv = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor_ultv = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Abierto = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Estado = table.Column<string>(type: "char(1)", nullable: true),
                    Pordes = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    Fecha_ing = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comenta = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Fecha_ultc = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor_ultc = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Zona = table.Column<string>(type: "char(3)", nullable: true),
                    Sector = table.Column<string>(type: "char(3)", nullable: true),
                    Credito = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Tipo_cli = table.Column<string>(type: "char(1)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fecha_nac = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: true),
                    Titulo = table.Column<string>(type: "char(2)", nullable: true),
                    Colegio = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Provin_col = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Ciudad_col = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Parentezco = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Nombre_rep = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    Lugarnacre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Ocupa_rep = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Cargo_rep = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Empre_rep = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Dire_rep = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Fonos_rep = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Email_rep = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Facultad = table.Column<string>(type: "char(2)", nullable: true),
                    Programa = table.Column<string>(type: "char(3)", nullable: true),
                    Especiali = table.Column<string>(type: "char(2)", nullable: true),
                    Clasifica = table.Column<string>(type: "char(3)", nullable: true),
                    Clicodint = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Patrocina = table.Column<string>(type: "char(6)", nullable: true),
                    Patcodint = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Tipotrans = table.Column<string>(type: "char(3)", nullable: true),
                    Cl_precio = table.Column<decimal>(type: "numeric(2, 0)", nullable: false),
                    Catego = table.Column<decimal>(type: "numeric(2, 0)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Es_contrib = table.Column<string>(type: "char(1)", nullable: true, defaultValue: "N"),
                    Estado_tar = table.Column<string>(type: "char(1)", nullable: true),
                    Digito_tar = table.Column<string>(type: "char(1)", nullable: true),
                    Profesion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Recipromo = table.Column<string>(type: "char(1)", nullable: true),
                    Usoprod = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Prodpara = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Tpusoprod = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Nhijos = table.Column<decimal>(type: "numeric(2, 0)", nullable: false),
                    St_civil = table.Column<string>(type: "char(1)", nullable: true),
                    Tipocli = table.Column<string>(type: "char(1)", nullable: true),
                    Tpdoc = table.Column<string>(type: "char(1)", nullable: true),
                    Cuota_1 = table.Column<decimal>(type: "numeric (10, 2)", nullable: false),
                    Tipo_1 = table.Column<string>(type: "char(2)", nullable: true),
                    Cuota_2 = table.Column<decimal>(type: "numeric (10, 2)", nullable: false),
                    Tipo_2 = table.Column<string>(type: "char(2)", nullable: true),
                    Codmain = table.Column<string>(type: "char(6)", nullable: true),
                    Replegal = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    Repced = table.Column<string>(type: "char(10)", nullable: true),
                    Repfono = table.Column<string>(type: "char(10)", nullable: true),
                    Fax = table.Column<string>(type: "char(10)", nullable: true),
                    Webpage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Paisnom = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    Provincia = table.Column<string>(type: "char(10)", nullable: true),
                    Planea = table.Column<string>(type: "char(10)", nullable: true),
                    Marca = table.Column<string>(type: "char(1)", nullable: true),
                    Marca2 = table.Column<string>(type: "char(1)", nullable: true),
                    Origen = table.Column<string>(type: "char(1)", nullable: true, defaultValue: "L"),
                    Seriefa = table.Column<string>(type: "char(6)", nullable: true),
                    Autofa = table.Column<string>(type: "char(10)", nullable: true),
                    F_emifa = table.Column<DateTime>(type: "datetime", nullable: false),
                    F_cadufa = table.Column<DateTime>(type: "datetime", nullable: false),
                    Conse = table.Column<string>(type: "char(8)", nullable: true),
                    Tipo_id = table.Column<string>(type: "char(1)", nullable: true),
                    Es_estatal = table.Column<string>(type: "char(1)", nullable: true),
                    Canton = table.Column<string>(type: "char(2)", nullable: true),
                    Parroquia = table.Column<string>(type: "char(7)", nullable: true),
                    Estcivil = table.Column<string>(type: "char(1)", nullable: true),
                    Origening = table.Column<string>(type: "char(1)", nullable: true),
                    Es_parterel = table.Column<int>(type: "int", nullable: false),
                    Retiene = table.Column<string>(type: "char(1)", nullable: true),
                    Antic_ncta = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Ciudad_respal = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Esparterel = table.Column<string>(type: "char(10)", nullable: true),
                    Tp_cliente = table.Column<string>(type: "char(1)", nullable: true),
                    T_cobro = table.Column<string>(type: "char(3)", nullable: true),
                    User_crea = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fec_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_mod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fec_mod = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DP05A110", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DP01A110_Codigo",
                table: "DP01A110",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_DP03ACOM_Codigo",
                table: "DP03ACOM",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_DP05A110_Codigo",
                table: "DP05A110",
                column: "Codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DP03ACOM");

            migrationBuilder.DropTable(
                name: "DP05A110");

            migrationBuilder.DropIndex(
                name: "IX_DP01A110_Codigo",
                table: "DP01A110");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "DP01A110",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
