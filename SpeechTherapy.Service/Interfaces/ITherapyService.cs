using SpeechTherapy.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SpeechTherapy.Service.Interfaces
{
    public interface ITherapyService
    {
        void AddTherapy(Therapy therapy);

        void ChangeDescription(int therapyId, Therapy Therapy);

        List<Therapy> GetAll();

        IQueryable<Therapy> TherapyToShow(int clientId, int therapistId);

        //void RemoveTherapy(int therapyId);
    }
}
