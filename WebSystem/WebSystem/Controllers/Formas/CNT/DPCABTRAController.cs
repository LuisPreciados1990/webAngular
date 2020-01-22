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
    [Route("api/DPCABTRA")]
    public class DPCABTRAController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DPCABTRAController(ApplicationDbContext context)
        { this._context = context; }

        [Route("createCabTra")]
        [HttpPost]
        public async Task<IActionResult> CreateCabTra([FromBody] DPCABTRA model)
        {
            if (ModelState.IsValid)
            {
                _context.DPCABTRA.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(model);
                }
                else
                { return BadRequest("Datos incorrectos"); }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("getDpcabtra/{tipo_asi}/{asiento}")]
        public async Task<ActionResult<DPCABTRA>> GetDpcabtra([FromRoute] string tipo_asi, [FromRoute] string asiento)
        {
            DPCABTRA cabtra = await _context.DPCABTRA.Where(m => m.Tipo_asi == tipo_asi && m.Asiento==asiento).FirstOrDefaultAsync();

            if (cabtra == null)
            {return BadRequest("No existe transacción..!");}

            if (cabtra.Anulado)
            { return BadRequest("Transacción se encuentra anulada: "+cabtra.Usuanu); }

            return Ok(cabtra);
        }

        [Route("updateCabTra/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCabTra([FromRoute] int id, [FromBody] DPCABTRA model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}