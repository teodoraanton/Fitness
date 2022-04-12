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
    public class ReservationController: ControllerBase
    {
        IReservationCollectionService _reservationCollectionService;

        public ReservationController(IReservationCollectionService reservationCollectionService)
        {
            _reservationCollectionService = reservationCollectionService;
        }

        /// <summary>
        ///     Return the list of reservations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReservation()
        {
            List<Reservation> reservations = await _reservationCollectionService.GetAll();
            return Ok(reservations);
        }

        /// <summary>
        ///     Add a new reservation in list
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Reservation cannot be null");
            }
            if (await _reservationCollectionService.Create(reservation))
            {
                return CreatedAtRoute("GetReservationById", new { id = reservation.Id.ToString() }, reservation);
            }
            return NoContent();
        }

        /// <summary>
        ///     Return on another route a reservations with a specified user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("reservation-user/{userName}")]
        public IActionResult GetByUser(string userName)
        {
            List<Reservation> reservations = _reservationCollectionService.getReservationsByName(userName);
            if (reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        /// <summary>
        ///     Return the reservation with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetReservationById")]
        public IActionResult GetByReservationId(Guid id)
        {
            Reservation reservation = _reservationCollectionService.Get(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        /// <summary>
        ///      Return the list of reservations with a reservation updated
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reservationToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateReservation(Guid id, [FromBody] Reservation reservationToUpdate)
        {
            if (reservationToUpdate == null)
            {
                return BadRequest("Reservation cannot be null");
            }
            if (await _reservationCollectionService.Update(reservationToUpdate, id))
            {
                return Ok();
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete a reservation with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            if (await _reservationCollectionService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
