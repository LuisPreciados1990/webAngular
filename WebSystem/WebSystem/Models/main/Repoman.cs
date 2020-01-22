using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.main
{
    public class Repoman
    {
        public int Id { get; set; }
        public string Namereport { get; set; }
        public string Sentencia { get; set; }
        public string Comentario { get; set; }
        public string Nick { get; set; }
        public string Tipo { get; set; }
        public string Ordenrep { get; set; }
        public string Agruparep { get; set; }
    }

    public class ParamRepo
    {
        public int Id { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
}
