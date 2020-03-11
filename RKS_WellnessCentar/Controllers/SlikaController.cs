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
    [Route("api/Slika")]
    public class SlikaController : Controller
    {
         #region CRUD Operations

		/// <summary>
        /// Get all Slika
        /// </summary>
        /// <returns>list of all Slika s </returns>
        /// <response code="200">Returns list of all Slikas</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Slika>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {

            return Json(DatabaseManager.Instance.GetList<Slika>(Startup.databaseName));
        }

        /// <summary>
        /// Get Slika by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Gets Slika> by id </returns>
        /// <response code="200">Returns Slika </response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(Slika), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult Get(long ID)
        {

            return Json(DatabaseManager.Instance.GetByID<Slika>(Startup.databaseName, ID));
        }

       
        /// <summary>
        /// Method for updating existing Slika
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Slika if successful</returns>
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
        public IActionResult Put([FromBody]Slika value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Update<Slika>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for inserting new Slika
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Slika if successful  </returns>
        /// <response code="200">Id of Slika</response>
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
        public IActionResult Post([FromBody]Slika value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Insert<Slika>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }


		 #endregion
    }
}
