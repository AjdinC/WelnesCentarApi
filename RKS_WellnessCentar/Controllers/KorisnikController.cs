using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RKS_WellnessCentar.DataAccess;
using RKS_WellnessCentar.Models;
using RKS_WellnessCentar;
using Newtonsoft.Json;
using static RKS_WellnessCentar.ViewModels.KorisnikVM;
using RKS_WellnessCentar.ViewModels;

namespace RKS_WellnessCentar.Controllers
{
    [Produces("application/json")]
    [Route("api/Korisnik")]
    public class KorisnikController : Controller
    {
         #region CRUD Operations

		/// <summary>
        /// Get all Korisnik
        /// </summary>
        /// <returns>list of all Korisnik s </returns>
        /// <response code="200">Returns list of all Korisniks</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Korisnik>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {

            return Json(DatabaseManager.Instance.GetList<Korisnik>(Startup.databaseName));
        }

        /// <summary>
        /// Get Korisnik by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Gets Korisnik> by id </returns>
        /// <response code="200">Returns Korisnik </response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(Korisnik), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult Get(long ID)
        {

            return Json(DatabaseManager.Instance.GetByID<Korisnik>(Startup.databaseName, ID));
        }

        
        /// <summary>
        /// Method for updating existing Korisnik
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Korisnik if successful</returns>
        /// <response code="200">Returns true</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Parameter value is null</response>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Put([FromBody]Korisnik value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Update<Korisnik>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for inserting new Korisnik
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Korisnik if successful  </returns>
        /// <response code="200">Id of Korisnik</response>
        /// <response code="400">Invalid parametars</response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Parameter value is null</response>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [HttpPost("Add")]
        public IActionResult Post([FromBody]Korisnik value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Insert<Korisnik>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }

        [HttpPut("updatelozinka")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePassword([FromBody]Lozinka value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.UpdateLozinka(Startup.databaseName, value.ID,value.Password))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        [HttpPut("azurirajprofil")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult AzurirajProfil([FromBody]Korisnik value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.AzurirajKorisnickiRacun(Startup.databaseName, value.ID, value.Ime,value.Prezime,value.Email,value.Telefon,value.KorisnickoIme))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        [HttpGet("{ID}/Rezervacije")]
        [ProducesResponseType(typeof(MojeRezervacijeVM), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetKorisnikRezervacije(long ID)
        {
            return Json(DatabaseManager.Instance.GetKorisnikRezervacije(Startup.databaseName, ID));
        }
        [HttpGet("rezervacije/{ID}")]
        [ProducesResponseType(typeof(Rezervacija), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetRezervacije(long ID)
        {
            return Json(DatabaseManager.Instance.GetRezervacije(Startup.databaseName, ID));
        }
        #endregion

    }
}
