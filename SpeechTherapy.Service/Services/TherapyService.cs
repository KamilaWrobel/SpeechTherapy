using SpeechTherapy.Model;
using SpeechTherapy.Model.Entities;
using SpeechTherapy.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeechTherapy.Service.Services
{
    public class TherapyService : ITherapyService
    {
        private readonly SpeechTherapyContext _db;

        public TherapyService(SpeechTherapyContext db)
        {
            _db = db;
        }

        public void AddTherapy(Therapy therapy)
        {
            _db.Therapies.Add(therapy);
            _db.SaveChanges();
        }

        public void ChangeDescription(int therapyId, Therapy therapy)
        {
            var foundTherapy = _db.Therapies.FirstOrDefault(o => o.Id == therapyId);
            foundTherapy.Description = therapy.Description;
            _db.SaveChanges();
        }

        public List<Therapy> GetAll()
        {
            return _db.Therapies.ToList();
        }

        public IQueryable<Therapy> TherapyToShow(int clientId, int therapistId)
        {
            return _db.Therapies.Where(o => o.ClientId == clientId && o.TherapistId == therapistId);

        }

        //public void RemoveTherapy(int therapyId)
        //{
        //    var foundTherapy = _db.Therapies.FirstOrDefault(o => o.Id == therapyId);
        //    foundTherapy.IsDeleted = true;
        //    _db.Entry(foundTherapist).State = System.Data.Entity.EntityState.Modified;
        //    _db.SaveChanges();
        //}
    }
}
