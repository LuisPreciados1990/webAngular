using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.CNT
{
    public class DP01A110
    {     
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Codigo_Aux { get; set; }
        public string Nombre { get; set; }
        public Boolean Detalle { get; set; }
        public string Estado { get; set; }        
    }
}
