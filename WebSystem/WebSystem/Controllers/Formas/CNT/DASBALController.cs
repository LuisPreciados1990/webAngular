using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.CNT;

namespace WebSystem.Controllers.Formas.CNT
{
    [Produces("application/json")]
    [Route("api/DASBAL")]
    public class DASBALController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DASBALController(ApplicationDbContext context)
        { this._context = context; }
        
        [HttpGet]
        [Route("getDasBal")]
        public async Task<ActionResult<DASBAL>> GetDasBal()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DASBAL das = await _context.DASBAL.Where(m => 1==1).FirstOrDefaultAsync();

            if (das == null)
            {
                return NotFound();
            }
            return Ok(das);
        }

        [HttpPut("updateDasBalId/{id}")]
        public async Task<IActionResult> UpdateDasBalId([FromRoute] int id, [FromBody] DASBAL model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}