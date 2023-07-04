using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBigBang.Models;
using AngularBigBang.Interfaces;
using AngularBigbang.Exeptions;
using AngularBigbang.Models.DTO;
using AngularBigbang.Models;
using AngularBigBang.Models.DTO;

namespace AngularBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;


        public BookingsController(IBookingService bookingService)
        {

            _bookingService=bookingService;
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Booking>> Register(Booking book)
        {
            try
            {
                Booking booked = await _bookingService.Register(book);
                if (booked == null)
                    return BadRequest(new Error(2, "Registration Not Successful"));
                return Created("User Registered", booked);
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(3, ise.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Booking>>> View_All_Booking()
        {
            try
            {
                var bookings = await _bookingService.View_All_Booking();
                if (bookings!= null)
                    return Ok(bookings);
                return BadRequest(new Error(10, "No Booking are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("byid")]

        public async Task<ActionResult<List<Booking>>> View_All_BookingById(int id)
        {
            try
            {
                var booking = await _bookingService.View_All_BookingById(id);
                if (booking !=null)
                    return Ok(booking);
                return BadRequest(new Error(10, "No Booking are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [ProducesResponseType(typeof(List<AvailabilityDTO>), StatusCodes.Status200OK)] // Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Failure Response
        [HttpGet("UnAvailableDate/{date}/{id}")]
        public async Task<ActionResult<List<AvailabilityDTO>>> GetUnAvailableDate(DateTime date, int id)
        {
            var availableDate = await _bookingService.GetUnAvailableDate(date, id);
            if (availableDate == null)
                return NotFound();

            return Ok(availableDate);
        }

        [ProducesResponseType(typeof(List<AvailabilityDTO>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("AvailableTimeSlot{date}")]
        public async Task<ActionResult<List<AvailabilityDTO>>> GetAvailableTimeSlot(DateTime date)
        {
            var availableDate = await _bookingService.GetAvailableTimeSlot(date);
            if (availableDate == null)
                return NotFound();

            return Ok(availableDate);
        }


    }
}
