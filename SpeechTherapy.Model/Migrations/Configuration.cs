namespace SpeechTherapy.Model.Migrations
{
    using SpeechTherapy.Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpeechTherapy.Model.SpeechTherapyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpeechTherapy.Model.SpeechTherapyContext context)
        {
            context.Therapists.AddOrUpdate(k => k.Name, new Therapist() { Name = "Kamila" });
            context.SaveChanges();
            context.Therapists.AddOrUpdate(k => k.Name, new Therapist() { Name = "Agnieszka" });
            context.SaveChanges();
            var therapist = context.Therapists.FirstOrDefault(o => o.Name == "Kamila");
            var therapist1 = context.Therapists.FirstOrDefault(o => o.Name == "Agnieszka");


            context.Clients.AddOrUpdate(k => k.Name, new Client() { Name = "Szymuœ", Therapist = therapist, Age = 4, StatusName= ClientStatusEnum.TherapyIsOn.ToString() });
            context.Clients.AddOrUpdate(k => k.Name, new Client() { Name = "Ola", Therapist = therapist1, Age = 1 });
            context.SaveChanges();

            var client = context.Clients.First(o => o.Name == "Szymuœ");
            var client2 = context.Clients.First(o => o.Name == "Ola");

            context.Therapies.AddOrUpdate(k => k.Description, new Therapy() { Date= DateTime.UtcNow, Therapist=therapist, Description= "Wzorowe zajêcia", Client = client});
            context.Therapies.AddOrUpdate(k => k.Description, new Therapy() { Date = DateTime.UtcNow, Therapist = therapist1, Description = "S³abe zajêcia", Client = client2});
            context.SaveChanges();

        }
    }
}
