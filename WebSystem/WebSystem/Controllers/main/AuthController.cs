using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebSystem.Models;
using WebSystem.Models.main;
using static WebSystem.Program;

namespace WebSystem.Controllers.main
{

    [Produces("application/json")]
    [Route("api/Account")]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContextRoot _context;
        private ApplicationDbContext _context2;

        private readonly IConfiguration _configuration;
        
        public AuthController(ApplicationDbContextRoot context, IConfiguration configuration, ApplicationDbContext context2)
        {
            this._context = context;
            this._context2 = context2;            
            this._configuration = configuration;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.UserLog = Encrypt.GetSHA256(model.UserLog);

                _context.USUARIOS.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return BuildToken(model);
                    //return Ok(model);
                }
                else
                { return BadRequest("Username or password invalid"); }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario userInfo)
        {
            if (ModelState.IsValid)
            {

                var result = await _context.USUARIOS.FirstOrDefaultAsync(x => 
                                    x.UserId == userInfo.UserId && x.UserLog == Encrypt.GetSHA256(userInfo.UserLog));

                if (result != null)
               {
                    //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    //optionsBuilder.UseSqlServer(@"Data Source = SYSWEBSERVICE\SQLEXPRESS; Initial Catalog = WEBCIA01; Persist Security Info = True; User ID = sa; Password = Rootpass1");
                    //https://forums.asp.net/t/2128171.aspx?CORE2+Changing+Connection+String+from+DBContext+DI+at+runtime

                    Globales.connectionString = result.CadenaConexion;
                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    optionsBuilder.UseSqlServer(result.CadenaConexion);

                    return BuildToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("xxx")]
        public async Task<string> Xxx([FromBody] Usuario userInfo)
        {
            if (ModelState.IsValid)
            {

                var result = await _context.USUARIOS.FirstOrDefaultAsync(x =>
                                    x.UserId == userInfo.UserId && x.UserLog == Encrypt.GetSHA256(userInfo.UserLog));

                if (result != null)
                {
                    Globales.connectionString = result.CadenaConexion;
                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    optionsBuilder.UseSqlServer(result.CadenaConexion);
                    //_context2 = new ApplicationDbContext(optionsBuilder.Options);
                    //return result.CadenaConexion;

                    return _context2.Database.GetDbConnection().ConnectionString;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
                    return "Usuario o contraseña invalido";
                }
            }
            else
            {
                return "Mal estructura";
            }
        }

        private IActionResult BuildToken(Usuario userInfo)
        {
            string keykey = "ABCDEFGHIJKLMNOPQERSU";
            //string userName = userInfo.UserName.Trim();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim("userName",userName),
            };

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keykey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }
        #region ejemplo
        [Route("crear")]
        [HttpPost]
        public IActionResult Crear([FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                _context.USUARIOS.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<Usuario> GetUser()
        {
            return _context.USUARIOS.ToList();
        }
        #endregion
    }
}