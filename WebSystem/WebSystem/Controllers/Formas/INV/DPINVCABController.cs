using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSystem.Models;
using WebSystem.Models.Formas.INV;

namespace WebSystem.Controllers.Formas.INV
{
    [Produces("application/json")]
    [Route("api/DPINVCAB")]
    public class DPINVCABController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DPINVCABController(ApplicationDbContext context)
        { this._context = context; }

        [Route("CreateInvCab")]
        [HttpPost]
        public async Task<IActionResult> CreateInvCab([FromBody] DPINVCAB model)
        {
            if (ModelState.IsValid)
            {
                _context.DPINVCAB.Add(model);
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

    }
}