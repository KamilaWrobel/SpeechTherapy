using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Model.Entities
{
    public class Therapist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<Client> Clients { get; set; }

        public virtual List<Therapy> Therapies { get; set; }
    }
}
