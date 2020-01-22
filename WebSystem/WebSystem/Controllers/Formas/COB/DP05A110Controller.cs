using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.COB;

namespace WebSystem.Controllers.Formas.COB
{
    [Produces("application/json")]
    [Route("api/DP05A110")]
    public class DP05A110Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public DP05A110Controller(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("GetClientes")]
        public IEnumerable<DP05A110> GetClientes()
        {
            return _context.DP05A110;
        }

        [HttpGet]
        [Route("GetClienteByCodigo/{codigo}")]
        public async Task<ActionResult<DP05A110>> GetClienteByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DP05A110 cliente = await _context.DP05A110.Where(m => m.Codigo == codigo).FirstOrDefaultAsync() ;

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpGet]
        [Route("GetClienteByNombre/{nombre}")]
        public async Task<ActionResult<List<DP05A110>>> GetClienteByNombre([FromRoute] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<DP05A110> cliente = await _context.DP05A110
                                        .Where(s=> EF.Functions.Like(s.Empcli, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

    }
}