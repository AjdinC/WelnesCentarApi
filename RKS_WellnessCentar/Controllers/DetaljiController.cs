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
    [Route("api/Detalji")]
    public class DetaljiController : Controller
    {
         #region CRUD Operations

		/// <summary>
        /// Get all Detalji
        /// </summary>
        /// <returns>list of all Detalji s </returns>
        /// <response code="200">Returns list of all Detaljis</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Detalji>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {

            return Json(DatabaseManager.Instance.GetList<Detalji>(Startup.databaseName));
        }

        /// <summary>
        /// Get Detalji by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Gets Detalji> by id </returns>
        /// <response code="200">Returns Detalji </response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(Detalji), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult Get(long ID)
        {

            return Json(DatabaseManager.Instance.GetByID<Detalji>(Startup.databaseName, ID));
        }

     
        /// <summary>
        /// Method for updating existing Detalji
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Detalji if successful</returns>
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
        public IActionResult Put([FromBody]Detalji value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Update<Detalji>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for inserting new Detalji
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Detalji if successful  </returns>
        /// <response code="200">Id of Detalji</response>
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
        public IActionResult Post([FromBody]Detalji value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Insert<Detalji>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
      

        #endregion
    }
}
