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
using WebSystem.Models.Formas.CNT;

namespace WebSystem.Controllers.Formas.CNT
{
    [Produces("application/json")]
    [Route("api/DP01AMOV")]
    public class DP01AMOVController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DP01AMOVController(ApplicationDbContext context)
        { this._context = context; }

        [Route("create01Amov")]
        [HttpPost]
        public async Task<IActionResult> Create01Amov([FromBody] List<DP01AMOV> model)
        {            
            _context.DP01AMOV.AddRange(model);
            if (await _context.SaveChangesAsync() > 0)
            {                    
                await Sp_01actsal(model[0].Tipo_asi, model[0].Asiento);
                return Ok(model);
            }
            else
            { return BadRequest("Datos incorrectos"); }            
        }

        public async Task<IActionResult> Sp_01actsal(string tipo_asi, string asiento)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            await _context.Database.ExecuteSqlCommandAsync($"sp_01actsal {tipo_asi},{asiento},1");            
            return Ok();
        }

        [HttpGet]
        [Route("getD01amov/{tipo_asi}/{asiento}")]        
        public async Task<ActionResult<DataTable>> GetD01amov([FromRoute] string tipo_asi, [FromRoute] string asiento)
        {
            string query = "select a.Id,a.Tipo_asi,a.Asiento,a.Linea,a.Fecha_asi,a.Codmov,a.Tipo,a.Refer,a.Concepto,a.Importe,a.Importe_ex, "+
                            "a.Cerrado,a.Ges_apl,a.Codpro,a.Numfac,a.Baseret,a.Por_ret,a.Chequeno,a.Con_ch,a.Con_rt,a.Numrete,a.Monto_anu, " +
                            "a.Anulado,a.Codsri,a.Comproba,a.Fecche,a.Centro_cos,a.S_sectra,a.S_tipcon,a.S_fecha1,a.S_fecha2,a.S_drawback, "+
                            "a.S_serie,a.S_secue,a.S_autoriza,a.S_idcre,a.S_nvt,a.S_nnc,a.S_nnd,a.S_base0,a.S_montoice,a.S_base12,a.S_codiva, "+
                            "a.S_montoiva,a.S_ri1,a.S_valiva1,a.S_codri1,a.S_montori1,a.S_ri2,a.S_valiva2,a.S_codri2,a.S_montori2,a.S_impcadu, "+
                            "a.Fecha,a.S_fecha0,a.Fecconci,a.Serie_rt,a.Autori_rt,a.Cod_flujo,a.Cat_ecp,isnull(b.Nombre, '')NombreCta, "+
                            "case when a.Importe > 0 then a.Importe else 0 end Debe,case when a.Importe < 0 then abs(a.Importe) else 0 end Haber "+
                            "from DP01AMOV a left "+
                            "join DP01A110 B ON a.Codmov = b.Codigo_Aux "+
                            "where a.Tipo_asi = @tipo_asi and a.Asiento = @asiento ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@tipo_asi", tipo_asi));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@asiento", asiento));
                    //adapter.Fill(dt);
                    await Task.Run(() => adapter.Fill(dt));
                }
            }

            return Ok(dt);
        }

        [Route("update01Amov")]
        [HttpPut]
        public async Task<IActionResult> Update01Amov([FromBody] List<DP01AMOV> model)
        {                           
            _context.UpdateRange(model);
            if (await _context.SaveChangesAsync() > 0)
            {
                await Sp_01actsal(model[0].Tipo_asi, model[0].Asiento);
                return Ok(model);
            }
            else
            { return BadRequest("Datos incorrectos"); }
        }

    }
}