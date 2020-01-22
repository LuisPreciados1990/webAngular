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
    [Route("api/Programa")]
    public class ProgramaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramaController(ApplicationDbContext context)
        { this._context = context; }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateProg([FromBody] Programa model)
        {
            if (ModelState.IsValid)
            {
                _context.WebProgramas.Add(model);
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
        [Route("GetByGestiTask/{gesti}/{task}")]
        public async Task<ActionResult<List<Programa>>> GetProgramas([FromRoute] string gesti, [FromRoute] string task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Programa> listaProgramas = await _context.WebProgramas.Where(m => m.GesApl == gesti && m.Tarea == task).ToListAsync();

            if (listaProgramas == null)
            {
                return NotFound();
            }

            return Ok(listaProgramas);            
        }

        [HttpGet]
        [Route("GetTask")]
        public IEnumerable<Programa> GetTask()
        {
            return _context.WebProgramas;
        }
    }
}