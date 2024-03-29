﻿using FitnessBackend.Models;
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
    public class GymController: ControllerBase
    {
        IGymCollectionService _gymsCollectionService;

        public GymController(IGymCollectionService gymsCollectionService)
        {
            _gymsCollectionService = gymsCollectionService;
        }

        /// <summary>
        ///     Return the list of gyms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGyms()
        {
            List<Gym> gyms = await _gymsCollectionService.GetAll();
            return Ok(gyms);
        }

        /// <summary>
        ///     Add a new gym in list
        /// </summary>
        /// <param name="gym"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGym ([FromBody] Gym gym)
        {
            if (gym == null)
            {
                return BadRequest("Gym cannot be null");
            }
            if (await _gymsCollectionService.Create(gym))
            {
                return CreatedAtRoute("GetGymById", new { id = gym.Id.ToString() }, gym);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym with a specified city id
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        [HttpGet("CityID/{cityID}")]
        public IActionResult GetGymByCityID(Guid cityID)
        {
            List<Gym> gyms = _gymsCollectionService.GetGymsByCityID(cityID);
            if (gyms == null)
            {
                return NotFound();
            }
            return Ok(gyms);
        }

        /// <summary>
        ///     Return the gym with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymById")]
        public IActionResult GetByGymId(Guid id)
        {
            Gym gym = _gymsCollectionService.Get(id);
            if (gym == null)
            {
                return NotFound();
            }
            return Ok(gym);
        }

        /// <summary>
        ///      Return the list of gyms with a gym updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGym(Guid id, [FromBody] Gym gymToUpdate)
        {
            if (gymToUpdate == null)
            {
                return BadRequest("Gym cannot be null");
            }
            if (await _gymsCollectionService.Update(gymToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGym/{id}")]
        public async Task<IActionResult> DeleteGym(Guid id)
        {
            if (await _gymsCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
