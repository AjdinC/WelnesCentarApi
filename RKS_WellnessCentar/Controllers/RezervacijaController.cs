using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RKS_WellnessCentar.DataAccess;
using RKS_WellnessCentar.Models;
using RKS_WellnessCentar;
using Newtonsoft.Json;

 
namespace RKS_WellnessCentar.Controllers
{
    [Produces("application/json")]
    [Route("api/Rezervacija")]
    public class RezervacijaController : Controller
    {
         #region CRUD Operations

		/// <summary>
        /// Get all Rezervacija
        /// </summary>
        /// <returns>list of all Rezervacija s </returns>
        /// <response code="200">Returns list of all Rezervacijas</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Rezervacija>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {

            return Json(DatabaseManager.Instance.GetList<Rezervacija>(Startup.databaseName));
        }

        /// <summary>
        /// Get Rezervacija by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Gets Rezervacija> by id </returns>
        /// <response code="200">Returns Rezervacija </response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(Rezervacija), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult Get(long ID)
        {

            return Json(DatabaseManager.Instance.GetByID<Rezervacija>(Startup.databaseName, ID));
        }

        /// <summary>
        /// Method for delete existing Rezervacija
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if delete is successful </returns>
        /// <response code="200">Returns true</response>
        /// <response code="400">Invalid parametars</response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Parameter value is null</response>
        [HttpDelete("Delete/{ID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Delete(long ID)
        {
            if (ID > 0)
            {
                if (DatabaseManager.Instance.Delete<Rezervacija>( Startup.databaseName,ID))
                    return Ok(true);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for updating existing Rezervacija
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Rezervacija if successful</returns>
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
        public IActionResult Put([FromBody]Rezervacija value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Update<Rezervacija>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for inserting new Rezervacija
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Rezervacija if successful  </returns>
        /// <response code="200">Id of Rezervacija</response>
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
        public IActionResult Post([FromBody]Rezervacija value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Insert<Rezervacija>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
       
        #endregion
    }
}
