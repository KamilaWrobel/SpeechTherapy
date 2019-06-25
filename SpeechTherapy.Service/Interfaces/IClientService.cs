using SpeechTherapy.Model.Entities;
using System.Collections.Generic;

namespace SpeechTherapy.Service.Interfaces
{
    public interface IClientService
    {
        void AddClient(Client client);

        void RemoveClient(int clientId);

        void CloseTherapy(int clientId);

        void ChangeAge(int clientId, int newAge);

        void ChangeTherapist(int clientId, int therapistId);

        List<Client> GetAll();

        Dictionary<string, string> GetClientStatuses();
    }
}
