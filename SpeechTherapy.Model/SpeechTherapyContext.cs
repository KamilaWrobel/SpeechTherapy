using SpeechTherapy.Model.Entities;
using SpeechTherapy.Model.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Model
{
    public class SpeechTherapyContext : DbContext
    {
        public SpeechTherapyContext() : base("name=dbConnectionString")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Therapy> Therapies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new TherapyConfiguration());
        }

    }
}
