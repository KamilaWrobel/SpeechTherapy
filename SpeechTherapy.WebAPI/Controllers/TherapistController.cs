using AutoMapper;
using SpeechTherapy.Model.Entities;
using SpeechTherapy.Service.Interfaces;
using SpeechTherapy.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SpeechTherapy.WebAPI.Controllers
{
    [RoutePrefix("api/Therapist")]
    public class TherapistController : ApiController
    {
        private readonly ITherapistService _therapistService;

        public TherapistController(ITherapistService therapistService)
        {
            _therapistService = therapistService;
        }


        [HttpPost]
        [Route("AddTherapist")]
        public IHttpActionResult AddTherapist([FromBody] Therapist therapist)
        {
            _therapistService.AddTherapist(therapist);
            return Ok();
        }

        [HttpDelete]
        [Route("RemoveTherapist/{therapistId}")]
        public IHttpActionResult RemoveTherapist(int therapistId)
        {
            _therapistService.RemoveTherapist(therapistId);
            return Ok();
        }

        [HttpPut]
        [Route("ChangeName/{therapistId}/{newName}")]
        public IHttpActionResult ChangeName(int therapistId, string newName)
        {
            _therapistService.ChangeName(therapistId, newName);
            return Ok();
        }

        [HttpPut]
        [Route("EditTherapist/{therapistId}")]
        public IHttpActionResult EditTherapist(int therapistId, [FromBody] Therapist therapist)
        {
            _therapistService.EditTherapist(therapistId, therapist);
            return Ok();
        }

        [HttpGet]
        [Route("TherapistGetAll")]
        public IHttpActionResult TherapistGetAll()
        {
            var dataDto = Mapper.Map<List<Therapist>, List<TherapistGetAllDto>>(_therapistService.TherapistGetAll());
            return Ok(dataDto);
        }


        [HttpGet]
        [Route("GetCurrentSchedule/{therapistId}")]
        public IHttpActionResult GetCurrentSchedule(int therapistId)
        {
            var currentScheduleDto = Mapper.Map<IQueryable<Therapy>, List<TherapyDto>>(_therapistService.GetCurrentSchedule(therapistId));


            var groupedData = currentScheduleDto.GroupBy(row => new
            {
                year = row.Date.Year,
                month = row.Date.Month,
                day = row.Date.Day
            })
            .Select(o => o.OrderByDescending(s => s.Date));

            foreach (var item in groupedData)
            {
                item.OrderByDescending(o => o.Date.Hour);
            }

            return Ok(groupedData);
        }
    }
}