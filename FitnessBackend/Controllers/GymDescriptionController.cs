using FitnessBackend.Models;
using FitnessBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymDescriptionController: ControllerBase
    {
        IGymDescriptionCollectionService _gymDescriptionCollectionService;

        public GymDescriptionController(IGymDescriptionCollectionService gymDescriptionCollectionService)
        {
            this._gymDescriptionCollectionService = gymDescriptionCollectionService;
        }

        /// <summary>
        ///     Return the list of descriptions of gyms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGymsDescription()
        {
            List<GymDescription> gyms = await _gymDescriptionCollectionService.GetAll();
            return Ok(gyms);
        }

        /// <summary>
        ///     Add a new gym in list
        /// </summary>
        /// <param name="gymDescription"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGymDescription([FromBody] GymDescription gymDescription)
        {
            if (gymDescription == null)
            {
                return BadRequest("Gym description cannot be null");
            }
            if (await _gymDescriptionCollectionService.Create(gymDescription))
            {
                return CreatedAtRoute("GetGymDescriptionById", new { id = gymDescription.Id.ToString() }, gymDescription);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym description with a specified gym id
        /// </summary>
        /// <param name="gymID"></param>
        /// <returns></returns>
        [HttpGet("description/{gymID}")]
        public IActionResult GetByGymID(Guid gymID)
        { 
            GymDescription gymDescription = _gymDescriptionCollectionService.GetGymDescriptionByGymID(gymID);
            if (gymDescription == null)
            {
                return NotFound();
            }
            return Ok(gymDescription);
        }

        /// <summary>
        ///     Return the gym description with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymDescriptionById")]
        public IActionResult GetByGymDescriptionId(Guid id)
        {
            GymDescription gymDescription = _gymDescriptionCollectionService.Get(id);
            if (gymDescription == null)
            {
                return NotFound();
            }
            return Ok(gymDescription);
        }

        /// <summary>
        ///      Return the list of gyms description with a gym description updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymDescriptionToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGymDescription(Guid id, [FromBody] GymDescription gymDescriptionToUpdate)
        {
            if (gymDescriptionToUpdate == null)
            {
                return BadRequest("Gym description cannot be null");
            }
            if (await _gymDescriptionCollectionService.Update(gymDescriptionToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym description with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGymDescription/{id}")]
        public async Task<IActionResult> DeleteGymDescription(Guid id)
        {
            if (await _gymDescriptionCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
