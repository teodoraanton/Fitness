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
    public class CityController: ControllerBase
    {
        ICityCollectionService _citiesCollectionService;

        public CityController(ICityCollectionService citiesCollectionService)
        {
            _citiesCollectionService = citiesCollectionService;
        }

        /// <summary>
        ///     Return the list of cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            List<City> cities = await _citiesCollectionService.GetAll();
            return Ok(cities);
        }



        /// <summary>
        ///     Add a new city in list
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest("City cannot be null");
            }
            if (await _citiesCollectionService.Create(city))
            {
                return CreatedAtRoute("GetCityById", new { id = city.Id.ToString() }, city);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return the city with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCityById")]
        public IActionResult GetByCityId(Guid id)
        {
            City city = _citiesCollectionService.Get(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        /// <summary>
        ///      Return the list of cities with a city updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cityToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCity(Guid id, [FromBody] City cityToUpdate)
        {
            if (cityToUpdate == null)
            {
                return BadRequest("City cannot be null");
            }
            if (await _citiesCollectionService.Update(cityToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a city with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            if (await _citiesCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }

}