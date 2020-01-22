using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.BAN;

namespace WebSystem.Controllers.Formas.BAN
{
    [Produces("application/json")]
    [Route("api/DP02A130")]
    public class DP02A130Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP02A130Controller(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("getReten")]
        public IEnumerable<DP02A130> GetReten()
        {
            return _context.DP02A130;
        }

        [HttpGet]
        [Route("getRetTempo")]
        public ActionResult<List<DBRETEN>> GetRetTempo()
        {
            List <DBRETEN> dbrete = _context.DBRETEN.FromSql($"select a.Id,a.Cuenta,a.Codigo,ltrim(rtrim(a.Nombre))Nombre," +
                            "a.Porcen,a.Tipret,a.Tpcompro,a.Fechaini,a.Fechafin,a.Te,a.Tbs,a.Codsri, a.Estado, a.GeneraRt0," +
                            "isnull(a.Visual_rep,'')Visual_rep, isnull(a.Sec_fic,'')Sec_fic,isnull(b.Nombre, '') NombreCta," +
                            "0.00 BaseRet, 0.00 ValorRet from DP02A130 a left " +                            
                            "join DP01A110 b on a.Cuenta = b.Codigo_Aux ").ToList();            
            return dbrete;
        }
    }
}