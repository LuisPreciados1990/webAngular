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
using WebSystem.Models.main;

namespace WebSystem.Controllers.main
{
    [Produces("application/json")]
    [Route("api/Repoman")]
    public class RepomanController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RepomanController(ApplicationDbContext context)
        { this._context = context; }

        [HttpPost]
        [Route("getRepoman/{nameRepo}")]

        public async Task<ActionResult<DataTable>> GetRepoman([FromRoute] string nameRepo, [FromBody] List<ParamRepo> paramRepo)
        {
            Repoman cta = await _context.Repoman.Where(m => m.Namereport == nameRepo).FirstOrDefaultAsync();

            if (cta == null)
            {return NotFound();}

            DataTable dt = new DataTable();                        
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {                
                using (SqlCommand cmd = new SqlCommand(cta.Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (ParamRepo item in paramRepo)
                    {
                        adapter.SelectCommand.Parameters.Add(new SqlParameter(item.Parameter.ToString(), item.Value.ToString()));
                    }

                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo_asi", "DI"));
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@asiento", "00000019"));
                    adapter.Fill(dt);
                }                
            }
            
            return Ok(dt);
        }

    }
}