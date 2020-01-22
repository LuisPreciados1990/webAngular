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
    [Route("api/DP01ACCO")]
    public class DP01ACCOController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP01ACCOController(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("getCCosto")]
        public IEnumerable<DP01ACCO> GetCCosto()
        {
            return _context.DP01ACCO;
        }

        [HttpGet]
        [Route("getCCostoByCodigo/{codigo}")]
        public async Task<ActionResult<DP01ACCO>> GetCCostoByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DP01ACCO cco = await _context.DP01ACCO.Where(m => m.Cod_centro == codigo).FirstOrDefaultAsync();

            if (cco == null)
            {
                return NotFound();
            }

            return Ok(cco);
        }

        [HttpGet]
        [Route("getCCostoByNombre/{nombre}")]
        public async Task<ActionResult<List<DP01ACCO>>> GetCCostoByNombre([FromRoute] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<DP01ACCO> cco = await _context.DP01ACCO
                                        .Where(s => EF.Functions.Like(s.Nombre, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();
            if (cco == null)
            {
                return NotFound();
            }
            return Ok(cco);
        }

        [HttpPost]
        [Route("saveCCosto")]
        public async Task<IActionResult> SaveCCosto([FromBody] DP01ACCO model)
        {
            if (ModelState.IsValid)
            {
                //Verifico si existe cuenta
                var cco = _context.DP01ACCO.Where(m => m.Cod_centro == model.Cod_centro).FirstOrDefault();
                if (cco != null)
                {
                    return BadRequest("Centro de Costo ya Existe..!");
                }

                //Ingreso Informacion
                _context.DP01ACCO.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                { return Ok(model); }
                else
                { return BadRequest("Datos incorrectos"); }
            }
            else
            { return BadRequest(ModelState); }
        }

        [HttpPut("updateCCostoById/{id}")]
        public async Task<IActionResult> UpdateCCostoById([FromRoute] int id, [FromBody] DP01ACCO model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("deleteCCostoById/{id}")]
        public async Task<IActionResult> DeleteCCostoById([FromRoute] int id)
        {
            //Verifico que la cuenta 
            var cco = await _context.DP01ACCO.FindAsync(id);
            if (cco == null)
            {
                return BadRequest("Centro de Costo no Existe..!");
            }

            //Verifico Movimientos de la cuenta
            var movi = _context.DP01AMOV.Where(m => m.Centro_cos == cco.Cod_centro).FirstOrDefault();
            if (movi != null)
            {
                return BadRequest("Existen movimientos con Centro de Costo..!");
            }
            
            _context.DP01ACCO.Remove(cco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}