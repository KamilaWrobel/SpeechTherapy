using SpeechTherapy.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Model.EntityConfigurations
{
    public class TherapyConfiguration : EntityTypeConfiguration<Therapy>
    {
        public TherapyConfiguration()
        {
            this.HasRequired(s => s.Client)
               .WithMany(o => o.Therapies)
               .HasForeignKey(s => s.ClientId)
               .WillCascadeOnDelete(false);

            this.HasRequired(s => s.Therapist)
               .WithMany(o => o.Therapies)
               .HasForeignKey(s => s.TherapistId)
               .WillCascadeOnDelete(false);
        }
    }
}
