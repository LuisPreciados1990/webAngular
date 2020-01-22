using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.INV;

namespace WebSystem.Controllers.Formas.INV
{
    [Produces("application/json")]
    [Route("api/DP03ACOM")]
    public class DP03ACOMController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DP03ACOMController(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("GetComprobaInv")]
        public IEnumerable<DP03ACOM> GetComprobaInv()
        {return _context.DP03ACOM;}

        [HttpGet]
        [Route("GetComprobaInvByGrupo/{grupo}")]
        public async Task<ActionResult<List<DP03ACOM>>> GetComprobaInvByGrupo([FromRoute] string grupo)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}
            List<DP03ACOM> comprobaInv = await _context.DP03ACOM.Where(m => m.Grupo == grupo).ToListAsync();

            if (comprobaInv == null)
            {return NotFound();}

            return Ok(comprobaInv);
        }

        [HttpGet]
        [Route("GetComprobaInvByCod/{codigo}")]
        public async Task<ActionResult<DP03ACOM>> GetComprobaInvByCod([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}
            DP03ACOM comprobaInv = await _context.DP03ACOM.Where(m => m.Codigo == codigo).FirstOrDefaultAsync();

            if (comprobaInv == null)
            {return NotFound();}

            return Ok(comprobaInv);
        }

        [HttpGet]
        [Route("getTransacINv/{codigo}/{grupo}")]
        public async Task<ActionResult<DP03ACOM>> GetTransacINv([FromRoute] string codigo, [FromRoute] string grupo)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            DP03ACOM comprobaInv = await _context.DP03ACOM.Where(m => m.Codigo == codigo && m.Grupo==grupo).FirstOrDefaultAsync();

            if (comprobaInv == null)
            { return NotFound(); }

            return Ok(comprobaInv);
        }

    }
}