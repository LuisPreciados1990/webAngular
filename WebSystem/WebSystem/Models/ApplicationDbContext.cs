using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models.Formas.BAN;
using WebSystem.Models.Formas.CNT;
using WebSystem.Models.Formas.COB;
using WebSystem.Models.Formas.ELEC;
using WebSystem.Models.Formas.INV;
using WebSystem.Models.Formas.PAG;
using WebSystem.Models.main;
using WebSystem.Models.StoredProcedure;
using static WebSystem.Program;
//esto es una prueba para el push
namespace WebSystem.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!string.IsNullOrEmpty(Globales.connectionString))
            {
                optionsBuilder.UseSqlServer(Globales.connectionString);
            }            
        }

        //protected override void OnModelCreating (ModelBuilder modelBuilder)
        //{            
        //    #region Creamos llaves primarias (PK) en las tablas   
        //    //modelBuilder.Entity<DP05A110>().HasKey(x => x.Codigo);
        //    modelBuilder.Entity<AlpTabla>().HasIndex(x => x.Master);
        //    modelBuilder.Entity<AlpTabla>().HasIndex(x => x.Codigo);
        //    modelBuilder.Entity<AlpTabla>().HasIndex(x => x.Nomtag);

        //    modelBuilder.Entity<DP01A110>().HasIndex(x => x.Codigo);

        //    modelBuilder.Entity<DP03ACOM>().HasIndex(x => x.Codigo);

        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Tipo);
        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Numero);
        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Grupo);
        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Fecha_tra);
        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Prov_cli);
        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Fac_pro);
        //    modelBuilder.Entity<DPINVCAB>().HasIndex(x => x.Integracnt);

        //    modelBuilder.Entity<DP03A110>().HasIndex(x => x.No_parte);
        //    modelBuilder.Entity<DP03A110>().HasIndex(x => x.Nombre);

        //    modelBuilder.Entity<DP05A110>().HasIndex(x => x.Codigo);
        //    modelBuilder.Entity<DP05A110>().HasIndex(x => x.Empcli);
        //    #endregion

        //    #region Creamos configuracion necesaria DP03ACOM
        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Codigo)
        //        .IsRequired().HasColumnType("char(2)");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Codigo_i)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Codigo_e)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Nombre)
        //        .IsRequired().HasColumnType("varchar(30)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Main)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tipo)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Pidecosto)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Inventario)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("S");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Numero)
        //        .IsRequired().HasColumnType("char(8)").HasDefaultValue("00000000");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Forma)
        //        .HasColumnType("char(8)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Forma2)
        //        .HasColumnType("char(8)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Grupo)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Iva)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("S");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Items)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("C");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Ocultaiva)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("N");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Permitedes)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("N");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tp_credito)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tp_aplica)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Integra)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Empresa)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tpintegra)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Generanc)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Ptovta)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.V_traspor)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.C_lineas)
        //        .HasColumnType("char(1)").HasDefaultValue("S");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tp_ret)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Control_it)
        //        .HasColumnType("char(1)").HasDefaultValue("N");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Num_it)
        //        .HasColumnType("decimal(2, 0)").HasDefaultValue(0);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tpnumera)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Od)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Ing_valdes)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Rma)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Iva_credi)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Ctaxpagar)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Devol)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Actcto)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Transp)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tipo2)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Ajuste)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Fiscal)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Signo)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Rt_manu)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Es_produ)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.At_exporta)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tiport)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Celectro)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Serie)
        //        .HasColumnType("char(6)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tp_op)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Es_lc)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Cta_provi)
        //        .HasColumnType("nvarchar(20)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tp_ent)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Es_exporta)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Validart)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Activa_mod)
        //        .HasColumnType("char(3)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Num_descu)
        //        .HasColumnType("decimal(2, 0)").HasDefaultValue(0);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.PrinterPDF)
        //        .HasColumnType("nvarchar(20)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Es_reserva)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.AjuSave)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Bode_linea)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Orden)
        //        .HasColumnType("decimal(5, 0)").HasDefaultValue(0);

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.CSaldo)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Tp_deuda)
        //        .HasColumnType("char(2)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03ACOM>().Property(x => x.Con_ctavta)
        //        .HasColumnType("nvarchar(20)").HasDefaultValue("");
        //    #endregion

        //    #region Creamos configuracion necesaria DP05A110
        //    modelBuilder.Entity<DP05A110>().Property(x => x.Codigo)
        //       .IsRequired().HasColumnType("char(6)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Cod_uees)
        //        .HasColumnType("nvarchar(10)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Pc_ncta)
        //        .HasColumnType("nvarchar(20)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Empcli)
        //        .IsRequired().HasColumnType("nvarchar(70)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Nomcli)
        //        .HasColumnType("nvarchar(70)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipopre)
        //        .HasColumnType("char(1)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Ruc)
        //        .HasColumnType("nvarchar(13)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Direccion)
        //        .HasColumnType("nvarchar(250)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Direccion2)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fono1)
        //        .HasColumnType("char(10)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fono2)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Vendedor)
        //        .HasColumnType("char(3)").HasDefaultValue("");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Diasp)
        //        .HasColumnType("numeric(3, 0)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fecha_ultv)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Valor_ultv)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Balance)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Abierto)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Estado)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Pordes)
        //        .HasColumnType("decimal(6, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fecha_ing)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Comenta)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fecha_ultc)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Valor_ultc)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Zona)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Sector)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Credito)
        //        .HasColumnType("decimal(18, 0)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipo_cli)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Ciudad)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fecha_nac)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Sexo)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Titulo)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Colegio)
        //        .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Provin_col)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Ciudad_col)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Parentezco)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Nombre_rep)
        //        .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Lugarnacre)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Ocupa_rep)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Cargo_rep)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Empre_rep)
        //        .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Dire_rep)
        //        .HasColumnType("nvarchar(80)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fonos_rep)
        //        .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Email_rep)
        //        .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Facultad)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Programa)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Especiali)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Clasifica)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Clicodint)
        //        .HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Patrocina)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Patcodint)
        //        .HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipotrans)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Cl_precio)
        //        .HasColumnType("numeric(2, 0)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Catego)
        //        .HasColumnType("numeric(2, 0)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Email)
        //        .HasColumnType("nvarchar(200)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Es_contrib)
        //        .HasColumnType("char(1)").HasDefaultValue("N");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Estado_tar)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Digito_tar)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Profesion)
        //        .HasColumnType("nvarchar(100)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Recipromo)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Usoprod)
        //        .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Prodpara)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tpusoprod)
        //        .HasColumnType("nvarchar(80)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Nhijos)
        //        .HasColumnType("numeric(2, 0)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.St_civil)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipocli)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tpdoc)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Cuota_1)
        //        .HasColumnType("numeric (10, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipo_1)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Cuota_2)
        //        .HasColumnType("numeric (10, 2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipo_2)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Codmain)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Replegal)
        //        .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Repced)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Repfono)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fax)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Webpage)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Paisnom)
        //        .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Provincia)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Planea)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Marca)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Marca2)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Origen)
        //        .HasColumnType("char(1)").HasDefaultValue("L");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Seriefa)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Autofa)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.F_emifa)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.F_cadufa)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Conse)
        //        .HasColumnType("char(8)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tipo_id)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Es_estatal)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Canton)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Parroquia)
        //        .HasColumnType("char(7)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Estcivil)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Origening)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Es_parterel)
        //        .HasColumnType("int");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Retiene)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Antic_ncta)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Ciudad_respal)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Esparterel)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Tp_cliente)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.T_cobro)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.User_crea)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fec_crea)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.User_mod)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP05A110>().Property(x => x.Fec_mod)
        //        .HasColumnType("datetime");

        //    #endregion

        //    #region Creamos configuracion necesaria DP03A110
        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pc_ncta)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pc_ncta2)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pc_ncta3)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.No_parte)
        //        .IsRequired().HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Codinter)
        //        .HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Nombre)
        //        .HasColumnType("nvarchar(100)").HasDefaultValue("");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Presentacion2)
        //        .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Aplica)
        //        .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Codbarra)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Tipo)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("N");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Modelo)
        //        .HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Proveedor)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Clase)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Subclase)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Origen)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Marca)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Desunidad)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Factor)
        //        .HasColumnType("decimal(6, 0)").HasDefaultValue(1);

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Desfactor)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Ubica)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Vstock)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("S");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Iva_sn)
        //        .IsRequired().HasColumnType("char(1)").HasDefaultValue("S");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Exmin)
        //        .HasColumnType("decimal(12, 3)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Exmax)
        //        .HasColumnType("decimal(12, 3)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.V_ultcom)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.F_ultcom)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.V_ultven)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.F_ultven)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpc1)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpc2)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpc3)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpc4)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpu1)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpu2)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Desunidad2)
        //        .HasColumnType("nvarchar(20)");            

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Hasta2)
        //        .HasColumnType("decimal(8, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpu3)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Desunidad3)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Hasta3)
        //        .HasColumnType("decimal(8, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpu4)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Desunidad4)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Hasta4)
        //        .HasColumnType("decimal(8, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpu5)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Desunidad5)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Hasta5)
        //        .HasColumnType("decimal(8, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pvpc5)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Imagen)
        //        .HasColumnType("nvarchar(100)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pesocaja)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Modipvp)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Modidescri)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pordes)
        //        .HasColumnType("decimal(6, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Comenta)
        //        .HasColumnType("nvarchar(150)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Estado)
        //        .HasColumnType("char(1)").HasDefaultValue("A");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Cubicau)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Cubicac)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Color)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Talla)
        //        .HasColumnType("char(3)");            

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Lasting)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Cantini)
        //        .HasColumnType("decimal(12, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Costini)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Ultcompra)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Costo_alor)
        //        .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.C_ultcom)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Cantini2)
        //        .HasColumnType("decimal(12, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Fecha_crea)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Fecha_modi)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Ult_prv)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Fecha_ve1)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Fecha_ve2)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pideser)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Es_precio)
        //        .HasColumnType("bit");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Imagen2)
        //        .HasColumnType("nvarchar(100)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Motor)
        //        .HasColumnType("nvarchar(25)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Anio)
        //        .HasColumnType("char(4)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Acceso)
        //        .HasColumnType("nvarchar(180)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Kmt)
        //        .HasColumnType("int");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Chasis)
        //       .HasColumnType("nvarchar(25)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Tipopr)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Vstock2)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Calidad)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Congelacion)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Corte)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Tip_peso)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Peso)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Empaque)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Presentacion)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Master)
        //        .HasColumnType("decimal(16, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Claint)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Pesobruto)
        //        .HasColumnType("decimal(16, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Codcomp)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Codvent)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.F_aju)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Tp_items)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.TieICE)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Porcomia)
        //        .HasColumnType("numeric (6, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Porcomib)            
        //        .HasColumnType("numeric (6, 2)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Meses)
        //        .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Subclase2)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.P2)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.P3)
        //        .HasColumnType("char(10)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcanti1)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcantf1)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcanti2)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcantf2)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcanti3)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcantf3)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcanti4)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcantf4)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcanti5)
        //        .HasColumnType("decimal(18, 6)");

        //    modelBuilder.Entity<DP03A110>().Property(x => x.Rcantf5)
        //        .HasColumnType("decimal(18, 6)");
        //    #endregion

        //    #region Creamos configuracion necesaria AlpTabla
        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Master)
        //        .IsRequired().HasColumnType("char(5)");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Codigo)
        //        .IsRequired().HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Nombre)
        //        .HasColumnType("nvarchar(200)");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Valor)
        //        .HasColumnType("decimal(15,2)").HasDefaultValue(0);

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Nomtag)
        //        .HasColumnType("nvarchar(10)").HasDefaultValue("");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Gestion)
        //        .HasColumnType("char(3)").HasDefaultValue("");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Pideval)
        //        .HasColumnType("bit").HasDefaultValue(false);

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Campo1)
        //        .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Grupo)
        //        .HasColumnType("nvarchar(70)").HasDefaultValue("");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Sgrupo)
        //        .HasColumnType("nvarchar(70)").HasDefaultValue("");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Campo2)
        //        .HasColumnType("nvarchar(30)").HasDefaultValue("");

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Lencod)
        //        .HasColumnType("int").HasDefaultValue(0);

        //    modelBuilder.Entity<AlpTabla>().Property(x => x.Valor2)
        //        .HasColumnType("decimal(16,2)");
        //    #endregion

        //    #region Creamos configuracion necesaria DPINVCAB
        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Tipo)
        //        .IsRequired().HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Numero)
        //        .IsRequired().HasColumnType("char(8)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Numero_b)
        //        .HasColumnType("nvarchar(15)").HasDefaultValue("");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Referencia)
        //        .HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Grupo)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Tipo_t)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_tra)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_ven)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Bodega_d)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Bodega)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Prov_cli)
        //        .HasColumnType("char(6)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vendedor)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Tp_precio)
        //        .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_mov)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Pordes)
        //        .HasColumnType("decimal(6, 2)").HasDefaultValue(0);

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_des)
        //        .HasColumnType("decimal(16, 2)").HasDefaultValue(0);

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Poriva)
        //        .HasColumnType("decimal(6, 2)").HasDefaultValue(0);

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_iva)
        //        .HasColumnType("decimal(16, 2)").HasDefaultValue(0);

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_trn)
        //        .HasColumnType("decimal(16, 2)").HasDefaultValue(0);

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Userfec)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Userfec_2)
        //        .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Usertim)
        //        .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Usercla)
        //        .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Comenta)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Comenta1)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Comenta2)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Comenta3)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vta_cli)
        //        .HasColumnType("nvarchar(40)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vta_ruc)
        //        .HasColumnType("nvarchar(13)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vta_dir)
        //        .HasColumnType("nvarchar(40)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vta_fo1)
        //        .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vta_fo2)
        //        .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Anulada)
        //        .HasColumnType("bit").HasDefaultValue(0);

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_anu2)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_anu)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Hora_anu)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.User_anu)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Abono)
        //         .HasColumnType("decimal(16, 2)").HasDefaultValue(0); 

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fac_pro)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Codigo_i)
        //         .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Codigo_e)
        //         .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Integracnt)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Vapor)
        //         .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fec_emb)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Semana)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Guia_remi)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Numfue)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Librasne)
        //         .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Pesone)
        //         .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Pesobru)
        //         .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Marca)
        //         .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Destino)
        //         .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cartonera)
        //         .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cancelapto)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Comprodev)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Van)
        //         .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cajero)
        //         .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Flete)
        //         .HasColumnType("decimal(16,2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Transporte)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Terminos)
        //         .HasColumnType("nvarchar(30)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.St)
        //         .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Canc_lote)
        //         .HasColumnType("bit");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Factura)
        //         .HasColumnType("char(8)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Dirdes)
        //         .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Remite)
        //         .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fec_ini)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fec_fin)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Trasladox)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Base_0)
        //         .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Base_tax)
        //         .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Val_trans)
        //         .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Porcom)
        //         .HasColumnType("decimal(6, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Integracos)
        //         .HasColumnType("char(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ordcom)
        //         .HasColumnType("char(8)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cubica_t)
        //         .HasColumnType("decimal(16, 4)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ano)
        //         .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Periodo)
        //         .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Catego)
        //         .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Programa)
        //         .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cuota)
        //         .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Contrib)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Rma)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ocompra)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.S_impcadu)
        //         .HasColumnType("char(8)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.S_autoriza)
        //         .HasColumnType("nvarchar(49)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Od)
        //         .HasColumnType("bit");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_ve1)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Status_flu)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_flu)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ctacont)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_ser)
        //         .HasColumnType("decimal(12, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Por_comitc)
        //         .HasColumnType("decimal(8, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Base_tc)
        //         .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valcomitc)
        //         .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Contabi)
        //         .HasColumnType("bit");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Impreso)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Desc_fac)
        //         .HasColumnType("nvarchar(80)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valor_rt)
        //         .HasColumnType("decimal(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Pesada)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Lote)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Contenedor)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Sellos)
        //         .HasColumnType("nvarchar(25)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Export)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.SubpartiAn)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Marcas)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Guia_placa)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Guia_nDestina)
        //         .HasColumnType("nvarchar(200)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Guia_RucDest)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Aguaje)
        //         .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Lrecibida)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Lbasura)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Rendimiento)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_lib)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_kil)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_caj)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Sobrante)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Sobr_basura)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Sobr_remite)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Sobr_rendi)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Peso_planta)
        //         .HasColumnType("numeric(18, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Trans_ruc)
        //         .HasColumnType("nvarchar(13)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Partida)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Transporta)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Llegada)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ruta)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ce_autoriz)
        //         .HasColumnType("nvarchar(49)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ce_clave)
        //         .HasColumnType("nvarchar(50)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ce_fecaut)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ce_activo)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ce_estado)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ce_deserra)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_clu)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Ap_comi)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Recibido)
        //         .HasColumnType("char(1)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Fecha_rec)
        //         .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Hora_rec)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.User_rec)
        //         .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Comenta_re)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Conceptox)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Rs_scan)
        //         .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.EstadoFac)
        //         .HasColumnType("bit");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Flete_loc)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Gasto_loc)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valor_fob)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Flete_int)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Seguro)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valor_cif)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valor_adu)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Gastos_lod)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valtransp)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Valotros)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_sub)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Tipo_trans)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Pais)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Doc_embar)
        //        .HasColumnType("nvarchar(15)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Pto_embar)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Tam_conte)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Num_conte)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Tipo_segur)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Embarque)
        //        .HasColumnType("datetime");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Liquida)
        //        .HasColumnType("nvarchar(20)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Import)
        //        .HasColumnType("nvarchar(10)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Come_anula)
        //        .HasColumnType("nvarchar(250)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Total_ice)
        //        .HasColumnType("decimal(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Csf_nombre)
        //        .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Csf_cedula)
        //        .HasColumnType("nvarchar(13)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Csf_direcc)
        //        .HasColumnType("nvarchar(70)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodigo_1)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.CpValor_1)
        //        .HasColumnType("numeric(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodpla_1)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpvalpla_1)
        //        .HasColumnType("numeric (6, 0)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodigo_2)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.CpValor_2)
        //        .HasColumnType("numeric(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodpla_2)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpvalpla_2)
        //        .HasColumnType("numeric (6, 0)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodigo_3)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.CpValor_3)
        //        .HasColumnType("numeric(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodpla_3)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpvalpla_3)
        //        .HasColumnType("numeric (6, 0)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodigo_4)
        //        .HasColumnType("char(2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.CpValor_4)
        //        .HasColumnType("numeric(16, 2)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpcodpla_4)
        //        .HasColumnType("char(3)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Cpvalpla_4)
        //        .HasColumnType("numeric (6, 0)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.Porpromc)
        //        .HasColumnType("numeric (16, 8)");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.EsCotiza)
        //        .HasColumnType("int");

        //    modelBuilder.Entity<DPINVCAB>().Property(x => x.CSaldo)
        //        .HasColumnType("char(1)");                           
        //    #endregion

        //}

        #region General
        //public DbSet<Usuario> WebUsuarios { get; set; }
        //public DbSet<Usuario> USUARIOS { get; set; }

        public DbSet<Gestion> WebGestiones { get; set; }
        public DbSet<Programa> WebProgramas { get; set; }
        public DbSet<Tarea> WebTareas { get; set; }

        public DbSet<AlpTabla> AlpTabla { get; set; }

        public DbSet<Repoman> Repoman { get; set; }
        public virtual DbSet<ParamRepo> ParamRepo { get; set; }

        public DbSet<Dbhelpgen> Dbhelpgen { get; set; }
        #endregion

        #region Contabilidad
        public DbSet<DP01A110> DP01A110 { get; set; }
        public DbSet<DPNUMERO> DPNUMERO { get; set; }
        public DbSet<DP01ACCO> DP01ACCO { get; set; }
        public DbSet<DASBAL> DASBAL { get; set; }

        public DbSet<DP01ASAL> DP01ASAL { get; set; }        
        public DbSet<DPCABTRA> DPCABTRA { get; set; }
        public DbSet<DP01AMOV> DP01AMOV { get; set; }
        #endregion

        #region Banco
        public DbSet<DP02A110> DP02A110 { get; set; }
        public DbSet<DP02A130> DP02A130 { get; set; }
        public virtual DbSet<DBRETEN> DBRETEN { get; set; }        
        #endregion

        #region Inventario
        public DbSet<DP03ACOM> DP03ACOM { get; set; }
        public DbSet<DP03AMOV> DP03AMOV { get; set; }
        public DbSet<DP03A110> DP03A110 { get; set; }        
        public DbSet<DPINVCAB> DPINVCAB { get; set; }
        public DbSet<DP03A130> DP03A130 { get; set; }
        #endregion

        #region Cuentas por Cobrar
        public DbSet<DP05A110> DP05A110 { get; set; }
        #endregion

        #region Cuentas por Pagar
        public DbSet<DP06A110> DP06A110 { get; set; }
        #endregion

        #region Factura Electronica
        public DbSet<APCIAS> APCIAS { get; set; }
        public DbSet<APESTAB> APESTAB { get; set; }
        public DbSet<APTABLA7> APTABLA7 { get; set; }
        #endregion

        #region Virtual
        public virtual DbSet<Secuancia> Secuancia { get; set; }        
        #endregion
    }
}
