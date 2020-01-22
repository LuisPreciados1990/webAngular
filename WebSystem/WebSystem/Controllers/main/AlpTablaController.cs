using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.main;

namespace WebSystem.Controllers.main
{
    [Produces("application/json")]
    [Route("api/AlpTabla")]
    public class AlpTablaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlpTablaController(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("GetAlpTabla/{nomtag}")]
        public async Task<ActionResult<List<AlpTabla>>> GetAlpTabla([FromRoute] string nomtag)
        {
         
            AlpTabla codigo = await _context.AlpTabla.Where(m => m.Nomtag == nomtag).FirstOrDefaultAsync();

            List<AlpTabla> alpTabla = await _context.AlpTabla
                                        .Where(m => m.Master == codigo.Codigo)
                                        .ToListAsync();

            if (alpTabla == null)
            {
                return NotFound();
            }

            return Ok(alpTabla);
        }

        [HttpGet]
        [Route("getAlpTablaCod/{nomtag}/{codigo}")]
        public async Task<ActionResult<AlpTabla>> GetAlpTablaCod([FromRoute] string nomtag, [FromRoute] string codigo)
        {            

            AlpTabla cod = await _context.AlpTabla.Where(m => m.Nomtag == nomtag).FirstOrDefaultAsync();

            AlpTabla alpTabla = await _context.AlpTabla
                                        .Where(m => m.Master == cod.Codigo && m.Codigo== codigo).FirstOrDefaultAsync();

            if (alpTabla == null)
            {
                return NotFound();
            }

            return Ok(alpTabla);
        }
    }
}