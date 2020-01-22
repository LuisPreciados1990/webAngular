using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.CNT
{
    public class DPCABTRA
    {
        public int Id { get; set; }
        public string Tipo_asi { get; set; }
        public string Asiento { get; set; }
        public DateTime? Fecha_asi { get; set; }
        public string Desc_asi { get; set; }
        public string Beneficiar { get; set; }
        public decimal Debitos { get; set; }
        public decimal Creditos { get; set; }
        public string Cedruc { get; set; }
        public string Chequeno { get; set; }
        public string Usuario { get; set; }
        public DateTime? Fechasys { get; set; }
        public string Horasys { get; set; }
        public Boolean Cerrado { get; set; }
        public Boolean Anulado { get; set; }
        public DateTime? Fechaanu { get; set; }
        public string Horaanu { get; set; }
        public string Usuanu { get; set; }
        public string Ges_apl { get; set; }
        public string Auditado { get; set; }
        public decimal Factor { get; set; }
        public string Ce_autoriz { get; set; }
        public string Ce_clave { get; set; }
        public DateTime? Ce_fecaut { get; set; }
        public string Ce_activo { get; set; }
        public string Ce_estado { get; set; }
        public string Ce_deserra { get; set; }
        public string Proveedor { get; set; }
        public string Glosa { get; set; }
        public decimal Base_0 { get; set; }
        public decimal Base_12 { get; set; }
        public decimal Valiva { get; set; }
        public decimal Total_liq { get; set; }
        public string Come_anula { get; set; }
    }
}
