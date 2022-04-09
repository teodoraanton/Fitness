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
    public class GymPricesController: ControllerBase
    {
        IGymPricesCollectionService _gymPricesCollectionService;

        public GymPricesController(IGymPricesCollectionService gymPricesCollectionService)
        {
            _gymPricesCollectionService = gymPricesCollectionService;
        }

        /// <summary>
        ///     Return the list of gyms prices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGymsPrices()
        {
            List<GymPrices> gymsPrices = await _gymPricesCollectionService.GetAll();
            return Ok(gymsPrices);
        }

        /// <summary>
        ///     Add a new gym price in list
        /// </summary>
        /// <param name="gymPrice"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGymPrice([FromBody] GymPrices gymPrice)
        {
            if (gymPrice == null)
            {
                return BadRequest("Gym price cannot be null");
            }
            if (await _gymPricesCollectionService.Create(gymPrice))
            {
                return CreatedAtRoute("GetGymPriceById", new { id = gymPrice.Id.ToString() }, gymPrice);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a gym prices with a specified gym id
        /// </summary>
        /// <param name="gymID"></param>
        /// <returns></returns>
        [HttpGet("price/{gymID}")]
        public IActionResult GetByGymID(Guid gymID)
        {
            List<GymPrices> gymPrices = _gymPricesCollectionService.GetGymPricesByGymID(gymID);
            if (gymPrices == null)
            {
                return NotFound();
            }
            return Ok(gymPrices);
        }

        /// <summary>
        ///     Return the gym price with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGymPriceById")]
        public IActionResult GetByGymPriceId(Guid id)
        {
            GymPrices gymPrices = _gymPricesCollectionService.Get(id);
            if (gymPrices == null)
            {
                return NotFound();
            }
            return Ok(gymPrices);
        }

        /// <summary>
        ///      Return the list of gym prices with a gym price updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gymPriceToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGymPrice(Guid id, [FromBody] GymPrices gymPriceToUpdate)
        {
            if (gymPriceToUpdate == null)
            {
                return BadRequest("Gym price cannot be null");
            }
            if (await _gymPricesCollectionService.Update(gymPriceToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a gym price with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteGymPrice/{id}")]
        public async Task<IActionResult> DeleteGymPrice(Guid id)
        {
            if (await _gymPricesCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
