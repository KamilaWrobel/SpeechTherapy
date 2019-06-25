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
    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpDelete]
        [Route("RemoveClient/{clientId}")]
        public IHttpActionResult RemoveClient(int clientId)
        {
            _clientService.RemoveClient(clientId);
            return Ok();
        }

        [HttpPost]
        [Route("AddClient")]
        public void AddClient([FromBody] Client client)
        {
            _clientService.AddClient(client);
        }

        [HttpPut]
        [Route("CloseTherapy/{clientId}")]
        public IHttpActionResult CloseTherapy(int clientId)
        {
            _clientService.CloseTherapy(clientId);
            return Ok();
        }

        [HttpPut]
        [Route("ChangeAge/{clientId}/{newAge}")]
        public IHttpActionResult ChangeRegistrationNumber(int clientId, int newAge)
        {
            _clientService.ChangeAge(clientId, newAge);
            return Ok();
        }

        [HttpPut]
        [Route("ChangeTherapist/{clientId}/{therapistId}")]
        public IHttpActionResult ChangeTherapist(int clientId, int therapistId)
        {
            _clientService.ChangeTherapist(clientId, therapistId);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var dataDto = Mapper.Map<List<Client>, List<ClientGetAllDto>>(_clientService.GetAll());
            return Ok(dataDto);
        }

        [HttpGet]
        [Route("GetClientStatuses")]
        public IHttpActionResult GetClientStatuses()
        {
            var dto = new EnumDto(_clientService.GetClientStatuses());
            return Ok(dto.Enums);
        }
    }
}