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
using AngularBigBang.Services;
using AngularBigbang.Models;

namespace AngularBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {

        private readonly ITimeslotService _timeslotService;


        public TimeSlotsController(ITimeslotService timeslotService)
        {
            _timeslotService = timeslotService;

        }

        [ProducesResponseType(typeof(TimeSlot), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<TimeSlot>>> View_All_TimeSlots()
        {
            try
            {
                var myTimeSlots = await _timeslotService.View_All_TimeSlots();
                if (myTimeSlots.Count > 0)
                    return Ok(myTimeSlots);
                return BadRequest(new Error(10, "No TimeSlots are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

    }
}
