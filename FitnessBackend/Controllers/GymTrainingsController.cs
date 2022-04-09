using Microsoft.AspNetCore.Mvc;
using FitnessBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessBackend.Models;

namespace FitnessBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymTrainingsController: ControllerBase
    {
        IGymTrainingsCollectionService _gymTrainingsCollectionService;

        public GymTrainingsController(IGymTrainingsCollectionService gymTrainingsCollectionService)
        {
            _gymTrainingsCollectionService = gymTrainingsCollectionService;
        }

        /// <summary>
        ///     Return the list of gyms trainings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGymsTrainings()
        {
            List<GymTrainings> gymTrainings = await _gymTrainingsCollectionService.GetAll();
            return Ok(gymTrainings);
        }

        /// <summary>
        ///     Add a new gym training in list
        /// </summary>
        /// <param name="gymTraining"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGymTraining([FromBody] GymTrainings gymTraining)
        {
            if (gymTraining == null)
            {
                return BadRequest("Gym training cannot be null");
            }
            if (await _gymTrainingsCollectionService.Create(gymTraining))
            {
                return CreatedAtRoute("GetGymTrainingById", new { id = gymTraining.Id.ToString() }, gymTraining);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym trainings with a specified gym id
        /// </summary>
        /// <param name="gymID"></param>
        /// <returns></returns>
        [HttpGet("trainings/{gymID}")]
        public IActionResult GetByGymID(Guid gymID)
        {
            List<GymTrainings> gymTrainings = _gymTrainingsCollectionService.GetGymTrainingsByGymID(gymID);
            if (gymTrainings == null)
            {
                return NotFound();
            }
            return Ok(gymTrainings);
        }

        /// <summary>
        ///     Return the gym training with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymTrainingById")]
        public IActionResult GetByGymTrainingId(Guid id)
        {
            GymTrainings gymTraining = _gymTrainingsCollectionService.Get(id);
            if (gymTraining == null)
            {
                return NotFound();
            }
            return Ok(gymTraining);
        }

        /// <summary>
        ///      Return the list of gym trainings with a gym training updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymTrainingToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGymTraining(Guid id, [FromBody] GymTrainings gymTrainingToUpdate)
        {
            if (gymTrainingToUpdate == null)
            {
                return BadRequest("Gym training cannot be null");
            }
            if (await _gymTrainingsCollectionService.Update(gymTrainingToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym training with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGymTraining/{id}")]
        public async Task<IActionResult> DeleteGymTraining(Guid id)
        {
            if (await _gymTrainingsCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
