using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeechTherapy.WebAPI.DTOs
{
    public class ClientGetAllDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int TherapistId { get; set; }

        public string StatusName { get; set; }
    }
}