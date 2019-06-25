using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Model.Entities
{
    public class Therapy
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int TherapistId { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Therapist Therapist { get; set; }

    }
}
