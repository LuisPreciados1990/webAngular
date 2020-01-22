using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.main
{
    public class Gestion
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Namebmp { get; set; }
        public List<Programa> SubMenu { get; set; } 
    }
}
