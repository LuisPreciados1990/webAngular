using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSystem.Models;
using WebSystem.Models.Formas.BAN;

namespace WebSystem.Controllers.Formas.BAN
{
    [Produces("application/json")]
    [Route("api/DP02A110")]
    public class DP02A110Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP02A110Controller(ApplicationDbContext context)
        { this._context = context; }

        [HttpGet]
        [Route("getBancos")]
        public IEnumerable<DP02A110> GetReten()
        {
            return _context.DP02A110;
        }

        [HttpGet]
        [Route("getBancosByCodigo/{codigo}")]
        public async Task<ActionResult<DP02A110>> GetPlanCtaByCodigo([FromRoute] string codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DP02A110 bco = await _context.DP02A110.Where(m => m.Codigobco == codigo).FirstOrDefaultAsync();

            if (bco == null)
            {
                return NotFound();
            }

            return Ok(bco);
        }

        [HttpPost]
        [Route("getBcoIngreso")]
        public ActionResult<DataTable> GetBcoIngreso()
        {
            string query =  "select a.codigobco codigo, a.nombrebco nombre, a.codmov,isnull(b.Nombre,'') nombreCta , a.cuentano ," +
                            "a.formato,0.00 valor,cast(getdate() as date) fecche,'' comentario,0 numeroch " +
                            "from dp02a110 a left join DP01A110 b on a.codmov = b.Codigo_Aux";
            

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;                    
                    adapter.Fill(dt);
                }
            }

            return Ok(dt);
        }

        [HttpGet]
        [Route("getBcoByNombre/{nombre}")]
        public async Task<ActionResult<List<DP02A110>>> GetBcoByNombre([FromRoute] string nombre)
        {
            List<DP02A110> bco = await _context.DP02A110
                                        .Where(s => EF.Functions.Like(s.Nombrebco, "%" + nombre + "%"))
                                        .Take(20).ToListAsync();

            if (bco == null)
            {
                return NotFound();
            }

            return Ok(bco);
        }

        [HttpPost]
        [Route("saveBco")]
        public async Task<IActionResult> SaveBco([FromBody] DP02A110 model)
        {
            if (ModelState.IsValid)
            {
                //Verifico si existe el banco
                var bco = _context.DP02A110.Where(m => m.Codigobco == model.Codigobco).FirstOrDefault();
                if (bco != null)
                {
                    return BadRequest("Banco ya Existe..!");
                }

                //Ingreso Informacion
                _context.DP02A110.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                { return Ok(model); }
                else
                { return BadRequest("Datos incorrectos"); }
            }
            else
            { return BadRequest(ModelState); }
        }

        [HttpPut("updateBcoById/{id}")]
        public async Task<IActionResult> UpdateBcoById([FromRoute] int id, [FromBody] DP02A110 model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("deleteBcoById/{id}")]
        public async Task<IActionResult> DeleteBcoById([FromRoute] int id)
        {
            //Verifico que la cuenta 
            var bco = await _context.DP02A110.FindAsync(id);
            if (bco == null)
            {
                return BadRequest("Banco no Existe..!");
            }

            _context.DP02A110.Remove(bco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}