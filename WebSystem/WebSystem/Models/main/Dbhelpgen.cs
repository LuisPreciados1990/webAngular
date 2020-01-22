using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.main
{
    public class Dbhelpgen
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Sentencia { get; set; }
        public string Titulo { get; set; }
        public string Comentario { get; set; }
        public decimal Orden { get; set; }
        public decimal Colbfoco { get; set; }
        public decimal Colffoco { get; set; }
        public decimal Colbstd { get; set; }
        public decimal Colfstd { get; set; }
        public string Ancho_col { get; set; }
        public decimal Alto_grid { get; set; }
        public string Titulo_col { get; set; }
        public string Mascampos { get; set; }
        public string S_col_din { get; set; }
    }
}
