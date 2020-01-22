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
    [Route("api/DP03A110")]
    public class DP03A110Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP03A110Controller(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("GetProductos")]
        public IEnumerable<DP03A110> GetProductos()
        {
            return _context.DP03A110;
        }

        [HttpGet]
        [Route("GetProductoByCodigo/{codigo}")]
        public async Task<ActionResult<DP03A110>> GetProductoByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DP03A110 producto = await _context.DP03A110.Where(m => m.No_parte == codigo).FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }
               
        [HttpGet]
        [Route("GetProductoByNombre/{nombre}")]
        public async Task<ActionResult<List<DP03A110>>> GetProductoByNombre([FromRoute] string nombre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<DP03A110> producto = await _context.DP03A110
                                        .Where(s => EF.Functions.Like(s.Nombre, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        [Route("SaveItem")]        
        public async Task<IActionResult> SaveItem([FromBody] DP03A110 model)
        {
            if (ModelState.IsValid)
            {
                _context.DP03A110.Add(model);
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
        [Route("CheckNoparte/{codigo}")]
        public bool CheckNoparte([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {return false;}

            DP03A110 producto = _context.DP03A110.Where(m => m.No_parte == codigo).FirstOrDefault();

            if (producto == null)
            {return false;}

            return true;
        }

    }
}