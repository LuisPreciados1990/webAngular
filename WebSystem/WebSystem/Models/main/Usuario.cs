using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.main
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserLog { get; set; }
        public string UserName { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string CadenaConexion { get; set; }
        public Boolean Estado { get; set; }        
    }
}
