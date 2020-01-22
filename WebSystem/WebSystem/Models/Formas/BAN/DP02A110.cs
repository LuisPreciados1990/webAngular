using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.BAN
{
    public class DP02A110
    {
        public int Id { get; set; }
        public string Codigobco { get; set; }
        public string Codmov { get; set; }
        public string Nombrebco { get; set; }
        public string Cuentano { get; set; }
        public Boolean Cheque { get; set; }
        public decimal Numeroch { get; set; }
        public string Formato { get; set; }
        public Boolean Pide_cenco { get; set; }
        public Boolean Ch_boucher { get; set; }
        public DateTime? Cierre_con { get; set; }
    }
}
