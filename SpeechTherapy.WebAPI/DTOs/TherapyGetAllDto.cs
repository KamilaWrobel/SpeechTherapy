using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeechTherapy.WebAPI.DTOs
{
    public class TherapyGetAllDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int TherapistId { get; set; }

        public int ClientId { get; set; }

        //public List<ClientsDto>
    }
}