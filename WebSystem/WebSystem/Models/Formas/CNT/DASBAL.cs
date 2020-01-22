using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.CNT
{
    public class DASBAL
    {
        public int Id { get; set; }
        public string Activo { get; set; }
        public string Pasivo { get; set; }
        public string Capital { get; set; }
        public string Egresos { get; set; }
        public string Ingresos { get; set; }
        public string Ord_activo { get; set; }
        public string Ord_pasivo { get; set; }
        public string Resultadod { get; set; }
        public string Resultadoa { get; set; }
        public string Acumuladod { get; set; }
        public string Acumuladoa { get; set; }
        public Boolean Eg_cencos { get; set; }
        public Boolean In_cencos { get; set; }
        public string Caja { get; set; }
        public string Ventas { get; set; }
        public string Cto_venta { get; set; }
        public string Gasto_des { get; set; }
        public string Trasnpor { get; set; }
        public string Impuesto { get; set; }
        public string Inter_por { get; set; }
    }
}
