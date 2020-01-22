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
    [Route("api/DP03AMOV")]
    public class DP03AMOVController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP03AMOVController(ApplicationDbContext context)
        { this._context = context; }

        [Route("CreateInvDet")]
        [HttpPost]
        public async Task<IActionResult> CreateInvDet([FromBody] DP03AMOV model)
        {
            if (ModelState.IsValid)
            {
                _context.DP03AMOV.Add(model);
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