using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.PAG;

namespace WebSystem.Controllers.Formas.PAG
{
    [Produces("application/json")]
    [Route("api/DP06A110")]
    public class DP06A110Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP06A110Controller(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("getProveedores")]
        public IEnumerable<DP06A110> GetProveedores()
        {
            return _context.DP06A110;
        }

        [HttpGet]
        [Route("getProveedorByCodigo/{codigo}")]
        public async Task<ActionResult<DP06A110>> GetProveedorByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DP06A110 proveedor = await _context.DP06A110.Where(m => m.Codigo == codigo).FirstOrDefaultAsync();

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        [HttpGet]
        [Route("getProveedorByNombre/{nombre}")]
        public async Task<ActionResult<List<DP06A110>>> GetProveedorByNombre([FromRoute] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<DP06A110> proveedor = await _context.DP06A110
                                        .Where(s => EF.Functions.Like(s.Empresa, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }
    }
}