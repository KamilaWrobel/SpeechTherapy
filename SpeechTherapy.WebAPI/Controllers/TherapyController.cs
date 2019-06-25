using AutoMapper;
using SpeechTherapy.Model;
using SpeechTherapy.Model.Entities;
using SpeechTherapy.Service.Interfaces;
using SpeechTherapy.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SpeechTherapy.WebAPI.Controllers
{
    [RoutePrefix("api/Therapy")]
    public class TherapyController : ApiController
    {
        private readonly ITherapyService _therapyService;

        public TherapyController(ITherapyService therapyService)
        {
            _therapyService = therapyService;
        }


        //[HttpDelete]
        //[Route("RemoveTherapy/{therapytId}")]
        //public IHttpActionResult RemoveTherapy(int therapyId)
        //{
        //    _therapyService.RemoveTherapy(therapyId);
        //    return Ok();
        //}

        [HttpPut]
        [Route("ChangeDescription/{therapyId}")]
        public IHttpActionResult ChangeDescription(int therapyId, [FromBody] Therapy therapy)
        {
            _therapyService.ChangeDescription(therapyId, therapy);
            return Ok();
        }

        [HttpPost]
        [Route("AddTherapy")]
        public IHttpActionResult AddTherapy([FromBody] Therapy therapy)
        {
            therapy.Date = therapy.Date.ToLocalTime();
            _therapyService.AddTherapy(therapy);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var dataDto = Mapper.Map<List<Therapy>, List<TherapyGetAllDto>>(_therapyService.GetAll());
            return Ok(dataDto);
        }

        [HttpGet]
        [Route("TherapyToShow/{clientId}/{therapistId}")]
        public IHttpActionResult TherapyToShow(int clientId, int therapistId)
        {
            var dataDto = Mapper.Map<IQueryable<Therapy>, List<TherapyToShowDto>>(_therapyService.TherapyToShow(clientId, therapistId));

            return Ok(dataDto);
        }

    }
}