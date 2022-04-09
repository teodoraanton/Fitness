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
    public class GymTrainersController: ControllerBase
    {
        IGymTrainersCollectionService _gymTrainersCollectionService;

        public GymTrainersController(IGymTrainersCollectionService gymTrainersCollectionService)
        {
            _gymTrainersCollectionService = gymTrainersCollectionService;
        }

        /// <summary>
        ///     Return the list of gyms trainers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGymsTrainers()
        {
            List<GymTrainers> gymsPrices = await _gymTrainersCollectionService.GetAll();
            return Ok(gymsPrices);
        }

        /// <summary>
        ///     Add a new gym trainer in list
        /// </summary>
        /// <param name="gymTrainers"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGymTrainer([FromBody] GymTrainers gymTrainers)
        {
            if (gymTrainers == null)
            {
                return BadRequest("Gym trainer cannot be null");
            }
            if (await _gymTrainersCollectionService.Create(gymTrainers))
            {
                return CreatedAtRoute("GetGymTrainerById", new { id = gymTrainers.Id.ToString() }, gymTrainers);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym trainer with a specified gym id
        /// </summary>
        /// <param name="gymID"></param>
        /// <returns></returns>
        [HttpGet("trainer/{gymID}")]
        public IActionResult GetByGymID(Guid gymID)
        {
            List<GymTrainers> gymTrainers = _gymTrainersCollectionService.GetGymTrainersByGymID(gymID);
            if (gymTrainers == null)
            {
                return NotFound();
            }
            return Ok(gymTrainers);
        }

        /// <summary>
        ///     Return the gym trainer with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymTrainerById")]
        public IActionResult GetByGymTrainerId(Guid id)
        {
            GymTrainers gymTrainer = _gymTrainersCollectionService.Get(id);
            if (gymTrainer == null)
            {
                return NotFound();
            }
            return Ok(gymTrainer);
        }

        /// <summary>
        ///      Return the list of gym trainers with a gym trainer updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymTrainerToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGymTrainer(Guid id, [FromBody] GymTrainers gymTrainerToUpdate)
        {
            if (gymTrainerToUpdate == null)
            {
                return BadRequest("Gym trainer cannot be null");
            }
            if (await _gymTrainersCollectionService.Update(gymTrainerToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym trainer with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGymTrainer/{id}")]
        public async Task<IActionResult> DeleteGymTrainer(Guid id)
        {
            if (await _gymTrainersCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
