using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBigBang.Models;
using AngularBigBang.Interfaces;
using AngularBigbang.Models.DTO;
using AngularBigBang.Models.DTO;
using AngularBigbang.Exeptions;
using AngularBigbang.Models;
using Microsoft.AspNetCore.Authorization;

namespace AngularBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;


        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;

        }

        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(Doctor doctorRegisterDTO)
        {
            try
            {
                UserDTO user = await _doctorService.Register(doctorRegisterDTO);
                if (user == null)
                    return BadRequest(new Error(2, "Registration Not Successful"));
                return Created("User Registered", user);
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


        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("staff")]
        public async Task<ActionResult<DoctorDTO?>> staffRegister(DoctorDTO doctorReg)
        {

            var result = await _doctorService.staffRegister(doctorReg);
            return Ok(result);
        }

        [ProducesResponseType(typeof(DoctorDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("deleteStaffinlist")]
        public async Task<ActionResult<UserRegisterDTO?>> deletestaffinlist(DoctorDTO doctorReg)
        {

            var result = await _doctorService.deletestaffinlist(doctorReg);
            return Ok(result);
        }


        [ProducesResponseType(typeof(List<DoctorDTO>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Doctor>>> View_All_StaffRequest()
        {
            var result = await _doctorService.View_All_StaffRequest();
            return Ok(result);

        }

        [Authorize]
        [ProducesResponseType(typeof(List<Doctor>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("getDoctor")]

        public async Task<ActionResult<List<Doctor>>> View_All_doctors()
        {
            try
            {
                var doctors = await _doctorService.View_All_doctors();
                if (doctors.Count > 0)
                    return Ok(doctors);
                return BadRequest(new Error(10, "No AdditionalCategoryMasters are Existing"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [HttpGet("getdotorbyname")]
        public async Task<ActionResult<Doctor>> getDoctorByName(string name)
        {
              try
            {
                var doctor = await _doctorService.getDoctorByName(name);
                if(doctor!=null)
                {
                    return Ok(doctor);
                }
                return null;
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

        [HttpGet("filter")]

        public async Task<ActionResult<List<Doctor>>> filterByDept(string dept)
        {
            try
            {
                var doctors = await _doctorService.filterByDept(dept);
                if (doctors != null)
                {
                    return Ok(doctors);
                }
                return null;

            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }

    }

}
