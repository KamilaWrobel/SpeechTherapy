using SpeechTherapy.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Model.Entities
{
    public enum ClientStatusEnum 
    {
        [StringValue("Klient oczekuje na objęcie terapią")]
        ClientIsWaiting,

        [StringValue("Klient jest w trakcie terapii")]
        TherapyIsOn,

        [StringValue("Klient zakończył terapię")]
        TherapyIsFinished,
    }

    public class Client
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? TherapistId { get; set; }
        public string StatusName { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Therapist Therapist { get; set; }
        public virtual List<Therapy> Therapies { get; set; }
    }
}
