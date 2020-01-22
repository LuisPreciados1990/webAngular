using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.BAN
{
    public class DP02A130
    {        
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Porcen { get; set; }
        public string Tipret { get; set; }
        public string Tpcompro { get; set; }
        public DateTime? Fechaini { get; set; }
        public DateTime? Fechafin { get; set; }
        public string Te { get; set; }
        public string Tbs { get; set; }
        public string Codsri { get; set; }
        public string Estado { get; set; }
        public string GeneraRt0 { get; set; }
        public string Visual_rep { get; set; }
        public string Sec_fic { get; set; }        
    }

    public class DBRETEN
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Porcen { get; set; }
        public string Tipret { get; set; }
        public string Tpcompro { get; set; }
        public DateTime? Fechaini { get; set; }
        public DateTime? Fechafin { get; set; }
        public string Te { get; set; }
        public string Tbs { get; set; }
        public string Codsri { get; set; }
        public string Estado { get; set; }
        public string GeneraRt0 { get; set; }
        public string Visual_rep { get; set; }
        public string Sec_fic { get; set; }
        public string NombreCta { get; set; }
        public decimal BaseRet { get; set; }
        public decimal ValorRet { get; set; }
    }
}
