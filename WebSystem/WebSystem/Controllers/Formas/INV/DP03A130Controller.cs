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
    [Route("api/DP03A130")]
    public class DP03A130Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP03A130Controller(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("getConsumosInv")]
        public IEnumerable<DP03A130> GetConsumosInv()
        {
            return _context.DP03A130;
        }

    }
}