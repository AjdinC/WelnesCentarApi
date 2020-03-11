using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RKS_WellnessCentar.DataAccess;
using RKS_WellnessCentar.Models;
using RKS_WellnessCentar.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RKS_WellnessCentar.Controllers
{
    [Produces("application/json")]
    [Route("api/autentifikacija")]
    public class AutentifikacijaController : Controller
    {
        [HttpPost("Login")]
        public IActionResult Post([FromBody]LoginVM value)
        {

            if (value != null)
            {
                return Json(DatabaseManager.Instance.Login(Startup.databaseName, value.KorisnickoIme, value.Lozinka));
            }
            return BadRequest();
        }

        [HttpPost("Registracija")]
        public IActionResult Post([FromBody]Korisnik value)
        {
            try
            {
                if (value != null)
                {
                    if (DatabaseManager.Instance.Insert<Korisnik>(Startup.databaseName, value))
                        return Ok(value.ID);
                    else return NotFound();
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }
    }
}
