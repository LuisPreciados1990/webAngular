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
    [Route("api/DP01A110")]
    public class DP01A110Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public DP01A110Controller(ApplicationDbContext context)
        { this._context = context; }
        
        [HttpGet]
        [Route("GetPlan")]
        public IEnumerable<DP01A110> GetPlan()        
        {
            return _context.DP01A110.OrderBy(x => x.Codigo);
        }

        [HttpGet]
        [Route("getPlanCtaByCodigo/{codigo}")]
        public async Task<ActionResult<DP01A110>> GetPlanCtaByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DP01A110 cta = await _context.DP01A110.Where(m => m.Codigo_Aux == codigo).FirstOrDefaultAsync();

            if (cta == null)
            {
                return NotFound();
            }

            return Ok(cta);
        }

        [HttpGet]
        [Route("getPlanCtaByNombre/{nombre}")]
        public async Task<ActionResult<List<DP01A110>>> GetPlanCtaByNombre([FromRoute] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<DP01A110> cta = await _context.DP01A110
                                        .Where(s => EF.Functions.Like(s.Nombre, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();

            if (cta == null)
            {
                return NotFound();
            }

            return Ok(cta);
        }

        [HttpGet]
        [Route("getPlanCtaByNombreOrAux/{param}")]
        public async Task<ActionResult<List<DP01A110>>> GetPlanCtaByNombreOrAux([FromRoute] string param)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}
            List<DP01A110> cta = await _context.DP01A110
                                        .Where(s => EF.Functions.Like(s.Nombre, "%" + param + "%")
                                        || EF.Functions.Like(s.Codigo_Aux, "%" + param + "%"))
                                        .Take(20).ToListAsync();
            if (cta == null)
            {return NotFound();}
            return Ok(cta);
        }

        [HttpPost]
        [Route("saveCta")]
        public async Task<IActionResult> SaveCta([FromBody] DP01A110 model)
        {
            if (ModelState.IsValid)
            {
                //Verifico si existe cuenta
                var cta = _context.DP01A110.Where(m => m.Codigo == model.Codigo).FirstOrDefault();
                if (cta != null)
                {
                    return BadRequest("Cuenta ya Existe..!");
                }

                //Ingreso Informacion
                _context.DP01A110.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {return Ok(model);}
                else
                { return BadRequest("Datos incorrectos"); }
            }
            else
            {return BadRequest(ModelState);}
        }

        [HttpPut("updateCtaById/{id}")]
        public async Task<IActionResult> UpdateCtaById([FromRoute] int id, [FromBody] DP01A110 model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }            
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("deleteCtaById/{id}")]
        public async Task<IActionResult> DeleteCtaById([FromRoute] int id)
        {
            //Verifico que la cuenta 
            var cta = await _context.DP01A110.FindAsync(id);
            if (cta == null)
            {
                return BadRequest("Cuenta no Existe..!");
            }

            //Vefifico que sea padre y no tenga hijos
            if (!cta.Detalle)
            {
                var ctah = _context.DP01A110.Where(s => EF.Functions.Like(s.Codigo, cta.Codigo + "%")).Count();
                if (ctah > 1)
                {
                    return BadRequest("Existen cuentas hijas..!");
                }                
            }

            //Verifico Movimientos de la cuenta
            var movi = _context.DP01AMOV.Where(m => m.Codmov == cta.Codigo_Aux).FirstOrDefault();
            if (movi != null)
            {
                return BadRequest("Existen movimientos con esta cuenta..!");
            }


            _context.DP01A110.Remove(cta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}