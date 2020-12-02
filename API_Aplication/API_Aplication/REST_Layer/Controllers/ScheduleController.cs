using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Aplication.BusinessLogicLayer.Models;
using API_Aplication.BusinessLogicLayer.Services;
using API_Aplication.REST_Layer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService _Scheduleservice;
        public ScheduleController(IScheduleService Scheduleservice)
        {
            _Scheduleservice = Scheduleservice;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ScheduleModel>> GetSchedules()
        {
            try
            {
                return Ok(_Scheduleservice.GetSchedules());
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpGet("{ScheduleId:int}", Name = "GetSchedule")]
        public ActionResult<ScheduleModel> GetSchedule(int ScheduleId)
        {
            try
            {
                return Ok(_Scheduleservice.GetSchedule(ScheduleId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<ScheduleModel> CreateSchedule([FromBody] ScheduleModel ScheduleModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ScheduleModel);
                }
                var url = HttpContext.Request.Host;
                var createdSchedule = _Scheduleservice.CreateSchedule(ScheduleModel);
                return CreatedAtRoute("GetSchedule", new { ScheduleId = createdSchedule.Id }, createdSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{ScheduleId:int}")]
        public ActionResult<bool> DeleteSchedule(int ScheduleId)
        {
            try
            {
                return Ok(_Scheduleservice.DeleteSchedule(ScheduleId));
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{ScheduleId:int}")]
        public ActionResult<ScheduleModel> UpdateSchedule(int ScheduleId, [FromBody] ScheduleModel ScheduleModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(ScheduleModel.Origin) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                return _Scheduleservice.UpdateSchedule(ScheduleId, ScheduleModel);
            }

            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}
