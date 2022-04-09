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
    public class GymScheduleController: ControllerBase
    {
        IGymScheduleCollectionService _gymScheduleCollectionService;

        public GymScheduleController(IGymScheduleCollectionService gymScheduleCollectionService)
        {
            _gymScheduleCollectionService = gymScheduleCollectionService;
        }

        /// <summary>
        ///     Return the list of gyms schedules
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGymsSchedules()
        {
            List<GymSchedule> gymsSchedules = await _gymScheduleCollectionService.GetAll();
            return Ok(gymsSchedules);
        }

        /// <summary>
        ///     Add a new gym in list
        /// </summary>
        /// <param name="gymSchedule"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGymSchedule([FromBody] GymSchedule gymSchedule)
        {
            if (gymSchedule == null)
            {
                return BadRequest("Gym schedule cannot be null");
            }
            if (await _gymScheduleCollectionService.Create(gymSchedule))
            {
                return CreatedAtRoute("GetGymScheduleById", new { id = gymSchedule.Id.ToString() }, gymSchedule);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym schedule with a specified gym id
        /// </summary>
        /// <param name="gymID"></param>
        /// <returns></returns>
        [HttpGet("schedule/{gymID}")]
        public IActionResult GetByGymID(Guid gymID)
        {
            List<GymSchedule> gymSchedules = _gymScheduleCollectionService.GetGymScheduleByGymID(gymID);
            if (gymSchedules == null)
            {
                return NotFound();
            }
            return Ok(gymSchedules);
        }

        /// <summary>
        ///     Return the gym schedule with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymScheduleById")]
        public IActionResult GetByGymScheduleId(Guid id)
        {
            GymSchedule gymSchedule = _gymScheduleCollectionService.Get(id);
            if (gymSchedule == null)
            {
                return NotFound();
            }
            return Ok(gymSchedule);
        }

        /// <summary>
        ///      Return the list of gyms schedules with a gym schedule updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymScheduleToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGymSchedule(Guid id, [FromBody] GymSchedule gymScheduleToUpdate)
        {
            if (gymScheduleToUpdate == null)
            {
                return BadRequest("Gym schedule cannot be null");
            }
            if (await _gymScheduleCollectionService.Update(gymScheduleToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym schedule with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGymSchedule/{id}")]
        public async Task<IActionResult> DeleteGymSchedule(Guid id)
        {
            if (await _gymScheduleCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
