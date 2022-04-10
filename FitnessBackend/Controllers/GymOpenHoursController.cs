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
    public class GymOpenHoursController: ControllerBase
    {
        IGymOpenHoursCollectionService _gymOpenHoursCollectionService;

        public GymOpenHoursController(IGymOpenHoursCollectionService gymOpenHoursCollectionService)
        {
            _gymOpenHoursCollectionService = gymOpenHoursCollectionService;
        }

        /// <summary>
        ///     Return the list of gyms open hours
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGymsOpenHours()
        {
            List<GymOpenHours> gymsOpenHours = await _gymOpenHoursCollectionService.GetAll();
            return Ok(gymsOpenHours);
        }

        /// <summary>
        ///     Add a new gym open hour in list
        /// </summary>
        /// <param name="gymOpenHour"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGymOpenHour([FromBody] GymOpenHours gymOpenHour)
        {
            if (gymOpenHour == null)
            {
                return BadRequest("Gym open hour cannot be null");
            }
            if (await _gymOpenHoursCollectionService.Create(gymOpenHour))
            {
                return CreatedAtRoute("GetGymOpenHourById", new { id = gymOpenHour.Id.ToString() }, gymOpenHour);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym open hours with a specified gym id
        /// </summary>
        /// <param name="gymID"></param>
        /// <returns></returns>
        [HttpGet("open-hour/{gymID}")]
        public IActionResult GetByGymID(Guid gymID)
        {
            List<GymOpenHours> gymOpenHour = _gymOpenHoursCollectionService.GetGymOpenHoursByGymID(gymID);
            if (gymOpenHour == null)
            {
                return NotFound();
            }
            return Ok(gymOpenHour);
        }

        /// <summary>
        ///     Return the gym open hour  with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymOpenHourById")]
        public IActionResult GetByGymPriceId(Guid id)
        {
            GymOpenHours gymOpenHour = _gymOpenHoursCollectionService.Get(id);
            if (gymOpenHour == null)
            {
                return NotFound();
            }
            return Ok(gymOpenHour);
        }

        /// <summary>
        ///      Return the list of gym open hours with a gym open hour updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymOpenHourToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGymOpenHour(Guid id, [FromBody] GymOpenHours gymOpenHourToUpdate)
        {
            if (gymOpenHourToUpdate == null)
            {
                return BadRequest("Gym open hour cannot be null");
            }
            if (await _gymOpenHoursCollectionService.Update(gymOpenHourToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym open hour with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGymOpenHour/{id}")]
        public async Task<IActionResult> DeleteGymOpenHour(Guid id)
        {
            if (await _gymOpenHoursCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
