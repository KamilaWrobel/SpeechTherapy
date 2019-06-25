using SpeechTherapy.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Model.EntityConfigurations
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            this.HasOptional(s => s.Therapist)
               .WithMany(o => o.Clients)
               .HasForeignKey(s => s.TherapistId)
               .WillCascadeOnDelete(false);
        }
    }
}
