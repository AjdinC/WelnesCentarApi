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
    [Route("api/StatusRezervacije")]
    public class StatusRezervacijeController : Controller
    {
         #region CRUD Operations

		/// <summary>
        /// Get all StatusRezervacije
        /// </summary>
        /// <returns>list of all StatusRezervacije s </returns>
        /// <response code="200">Returns list of all StatusRezervacijes</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<StatusRezervacije>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {

            return Json(DatabaseManager.Instance.GetList<StatusRezervacije>(Startup.databaseName));
        }

        /// <summary>
        /// Get StatusRezervacije by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Gets StatusRezervacije> by id </returns>
        /// <response code="200">Returns StatusRezervacije </response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(StatusRezervacije), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult Get(long ID)
        {

            return Json(DatabaseManager.Instance.GetByID<StatusRezervacije>(Startup.databaseName, ID));
        }

      
        /// <summary>
        /// Method for updating existing StatusRezervacije
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of StatusRezervacije if successful</returns>
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
        public IActionResult Put([FromBody]StatusRezervacije value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Update<StatusRezervacije>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for inserting new StatusRezervacije
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of StatusRezervacije if successful  </returns>
        /// <response code="200">Id of StatusRezervacije</response>
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
        public IActionResult Post([FromBody]StatusRezervacije value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Insert<StatusRezervacije>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }


		 #endregion
    }
}
