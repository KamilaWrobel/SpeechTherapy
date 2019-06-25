using SpeechTherapy.Model;
using SpeechTherapy.Model.Entities;
using SpeechTherapy.Service.EnumHelpers;
using SpeechTherapy.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SpeechTherapy.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly SpeechTherapyContext _db;

        public ClientService(SpeechTherapyContext db)
        {
            _db = db;
        }

        public void AddClient(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
        }

        public void ChangeAge(int clientId, int newAge)
        {
            var foundClient = _db.Clients.FirstOrDefault(o => o.Id == clientId);
            foundClient.Age = newAge;
            _db.Entry(foundClient).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void CloseTherapy(int clientId)
        {
            var foundClient= _db.Clients.FirstOrDefault(o => o.Id == clientId);

            var finishedStatusName = ClientStatusEnum.TherapyIsFinished.ToString();

            foundClient.StatusName = finishedStatusName;
            _db.Entry(foundClient).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveClient(int clientId)
        {
            var foundClient = _db.Clients.FirstOrDefault(o => o.Id == clientId);
            foundClient.IsDeleted = true;
            _db.Entry(foundClient).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

        }

        public void ChangeTherapist(int clientId, int therapistId)
        {
            var client = _db.Clients.FirstOrDefault(o => o.Id == clientId);
            client.TherapistId = therapistId;
            _db.Entry(client).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public List<Client> GetAll()
        {
            return _db.Clients.Where(o => o.IsDeleted == false).ToList();

        }

        public Dictionary<string, string> GetClientStatuses()
        {
            return ClientStatusEnumHelper.GetClientStatusEnumValues();
        }
    }
}
