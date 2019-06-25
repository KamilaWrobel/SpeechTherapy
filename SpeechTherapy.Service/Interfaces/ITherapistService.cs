using SpeechTherapy.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SpeechTherapy.Service.Interfaces
{
    public interface ITherapistService
    {
        void AddTherapist(Therapist therapist);

        void RemoveTherapist(int therapistId);

        void ChangeName(int therapistId, string newName);

        void EditTherapist(int therapistId, Therapist therapist);

        List<Therapist> TherapistGetAll();

        IQueryable<Therapy> GetCurrentSchedule(int therapistId);
    }
}
