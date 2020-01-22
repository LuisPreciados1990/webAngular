using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.CNT;
using System.Data.SqlClient;
using WebSystem.Models.StoredProcedure;

namespace WebSystem.Controllers.Formas.CNT
{
    [Produces("application/json")]
    [Route("api/DPNUMERO")]
    public class DPNUMEROController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DPNUMEROController(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("getDPNumero")]
        public IEnumerable<DPNUMERO> GetDPNumero()
        {return _context.DPNUMERO;}

        [HttpGet]
        [Route("getTrnCntByCodigo/{codigo}")]
        public async Task<ActionResult<DPNUMERO>> GetTrnCntByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}

            DPNUMERO trnCnt = await _context.DPNUMERO.Where(m => m.Tipo_asi == codigo).FirstOrDefaultAsync();
            if (trnCnt == null)
            {return NotFound();}
            return Ok(trnCnt);
        }

        [HttpGet]
        [Route("getTrnCntByNombre/{nombre}")]
        public async Task<ActionResult<List<DPNUMERO>>> GetPlanCtaByNombre([FromRoute] string nombre)
        {
            if (!ModelState.IsValid)
            {return BadRequest(ModelState);}

            List<DPNUMERO> trnCnt = await _context.DPNUMERO
                                        .Where(s => EF.Functions.Like(s.Nombre, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();
            if (trnCnt == null)
            {return NotFound();}
            return Ok(trnCnt);
        }

        [HttpPost]
        [Route("saveDpnumero")]
        public async Task<IActionResult> SaveDpnumero([FromBody] DPNUMERO model)
        {
            if (ModelState.IsValid)
            {
                //Verifico si existe transacción
                var cta = _context.DPNUMERO.Where(m => m.Tipo_asi == model.Tipo_asi).FirstOrDefault();
                if (cta != null)
                {
                    return BadRequest("Codigo ya Existe..!");
                }

                //Ingreso Informacion
                _context.DPNUMERO.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                { return Ok(model); }
                else
                { return BadRequest("Datos incorrectos"); }
            }
            else
            { return BadRequest(ModelState); }
        }

        [HttpPut("updateDpnumero/{id}")]
        public async Task<IActionResult> UpdateCtaById([FromRoute] int id, [FromBody] DPNUMERO model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("deleteDpnumeroById/{id}")]
        public async Task<IActionResult> DeleteDpnumeroById([FromRoute] int id)
        {
            //Verifico que la cuenta 
            var dpnum = await _context.DPNUMERO.FindAsync(id);
            if (dpnum == null)
            {
                return BadRequest("Codigo no Existe..!");
            }
            
            //Verifico Movimientos de transaccion
            var movi = _context.DPCABTRA.Where(m => m.Tipo_asi == dpnum.Tipo_asi).FirstOrDefault();
            if (movi != null)
            {
                return BadRequest("Existen movimientos con esta transacción..!");
            }
            
            _context.DPNUMERO.Remove(dpnum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPost]
        //[Route("secuanciaCnt")]
        //public async Task<ActionResult<Secuancia>> SecuanciaCnt([FromBody] Sp_Numsecu p)        
        //{
        //    Secuancia secuancia = await _context.Secuancia.FromSql($"sp_Numsecu {p.Tipo},{p.Modulo},{p.Numero},{p.DevHVA},{p.Fecha} ").FirstOrDefaultAsync();
        //    return secuancia;
        //}

        [HttpPost]
        [Route("secuenciaCnt")]
        public ActionResult<Secuancia> SecuenciaCnt([FromBody] Sp_Numsecu p)
        {
            Secuancia secuancia = _context.Secuancia.FromSql($"sp_Numsecu {p.Tipo},{p.Modulo},{p.Numero},{p.DevHVA},{p.Fecha} ").FirstOrDefault();
            return secuancia;
        }

        [HttpGet]
        [Route("getRetenci")]
        public IEnumerable<DPNUMERO> GetRetenci()
        { return _context.DPNUMERO.Where(x => x.Es_retenci=="S"); }

        [HttpGet]
        [Route("getRetenciById/{codigo}")]
        public async Task<ActionResult<DPNUMERO>> GetRetenciById([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            DPNUMERO trnCnt = await _context.DPNUMERO.Where(m => m.Tipo_asi == codigo && m.Es_retenci=="S").FirstOrDefaultAsync();
            if (trnCnt == null)
            { return NotFound(); }
            return Ok(trnCnt);
        }


    }
}