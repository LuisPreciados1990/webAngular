using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.main;

namespace WebSystem.Controllers.main
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Gestion")]
    public class GestiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestiController(ApplicationDbContext context)
        { this._context = context; }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateGesti([FromBody] Gestion model)
        {
            if (ModelState.IsValid)
            {
                _context.WebGestiones.Add(model);
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
        [Route("GetGesti")]
        public IEnumerable<Gestion> GetGesti()
        {            
            return _context.WebGestiones;
        }

        [HttpGet]
        [Route("getGestiMenu")]
        public  ActionResult<IEnumerable<Gestion>> GetGestiMenu()
        {
            return _context.WebGestiones.Include(x => x.SubMenu).ToList();
        }
    }
}