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
    [Route("api/Dbhelpgen")]
    public class DbhelpgenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DbhelpgenController(ApplicationDbContext context)
        { this._context = context; }

        [HttpPost]
        [Route("getHelpgen/{nameHelp}")]
        public async Task<ActionResult<DataTable>> GetRepoman([FromRoute] string nameHelp)
        {
            Dbhelpgen help = await _context.Dbhelpgen.Where(m => m.Codigo == nameHelp).FirstOrDefaultAsync();

            if (help == null)
            { return NotFound(); }

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(help.Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;                    
                    adapter.Fill(dt);
                }
            }
            return Ok(dt);
        }

    }
}