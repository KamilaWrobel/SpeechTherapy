using SpeechTherapy.Model;
using SpeechTherapy.Model.Entities;
using SpeechTherapy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeechTherapy.Service.Services
{
    public class TherapistService : ITherapistService
    {
        private readonly SpeechTherapyContext _db;

        public TherapistService(SpeechTherapyContext db)
        {
            _db = db;
        }

        public void AddTherapist(Therapist therapist)
        {
            _db.Therapists.Add(therapist);
            _db.SaveChanges();
        }

        public void ChangeName(int therapistId, string newName)
        {
            var foundTherapist = _db.Therapists.FirstOrDefault(o => o.Id == therapistId);
            foundTherapist.Name = newName;
            _db.Entry(foundTherapist).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void EditTherapist(int therapistId, Therapist therapist)
        {
            var foundTherapist = _db.Therapists.FirstOrDefault(o => o.Id == therapistId);
            foundTherapist.Name = therapist.Name;
            //_db.Entry(foundTherapist).State = System.Data.Entity.EntityState.Modified;
            //_db.Therapists.Attach(foundTherapist);
            _db.SaveChanges();
        }

        public void RemoveTherapist(int therapistId)
        {
            var foundTherapist = _db.Therapists.FirstOrDefault(o => o.Id == therapistId);
            foundTherapist.IsDeleted = true;
            _db.Entry(foundTherapist).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public List<Therapist> TherapistGetAll()
        {
            return _db.Therapists.Where(o => o.IsDeleted == false).ToList();
        }

        public IQueryable<Therapy> GetCurrentSchedule(int therapistId)
        {
            var startDate = DateTime.Now.AddDays(-2);
            var endDate = DateTime.Now.AddDays(3);

            var selectedData = _db.Therapies.Where(o => o.Date >= startDate && o.Date <= endDate && o.Therapist.Id==therapistId);

            return selectedData;
        }
    }
}
