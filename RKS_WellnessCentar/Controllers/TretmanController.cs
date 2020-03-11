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
    [Route("api/Tretman")]
    public class TretmanController : Controller
    {
         #region CRUD Operations

		/// <summary>
        /// Get all Tretman
        /// </summary>
        /// <returns>list of all Tretman s </returns>
        /// <response code="200">Returns list of all Tretmans</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(List<Tretman>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
         {

            return Json(DatabaseManager.Instance.GetList<Tretman>(Startup.databaseName));
        }

        /// <summary>
        /// Get Tretman by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Gets Tretman> by id </returns>
        /// <response code="200">Returns Tretman </response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("{ID}")]
        [ProducesResponseType(typeof(Tretman), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult Get(long ID)
        {

            return Json(DatabaseManager.Instance.GetByID<Tretman>(Startup.databaseName, ID));
        }

       
        /// <summary>
        /// Method for updating existing Tretman
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Tretman if successful</returns>
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
        public IActionResult Put([FromBody]Tretman value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Update<Tretman>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// <summary>
        /// Method for inserting new Tretman
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Id of Tretman if successful  </returns>
        /// <response code="200">Id of Tretman</response>
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
        public IActionResult Post([FromBody]Tretman value)
        {

            if (value != null)
            {
                if (DatabaseManager.Instance.Insert<Tretman>(Startup.databaseName, value))
                    return Ok(value.ID);
                else return NotFound();
            }
            return NotFound();
        }
        /// </summary>
        /// <returns>list of all Tretman s </returns>
        /// <response code="200">Returns list of all Tretmans</response>
        /// <response code="400">Invalid parametars </response>
        /// <response code="403">Forbidden</response>
        /// <response code="401">Unauthorized</response>
        /// 
        [HttpGet("slike")]
        [ProducesResponseType(typeof(List<dynamic>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetTretmaniSlike()
        {

            return Json(DatabaseManager.Instance.GetTretmaniSlike<dynamic>(Startup.databaseName));
        }
        [HttpGet("{ID}/Detalji")]
        [ProducesResponseType(typeof(Detalji), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        public IActionResult GetTretmanDetalji(long ID)
        {
            return Json(DatabaseManager.Instance.GetTretmanDetalji(Startup.databaseName, ID));
        }
        #endregion
    }
}
