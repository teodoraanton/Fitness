using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymDescriptionCollectionService: IGymDescriptionCollectionService
    {
        private readonly IMongoCollection<GymDescription> _gymsDescription;

        public GymDescriptionCollectionService(IMongoDBSettingsGymDescription settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gymsDescription = database.GetCollection<GymDescription>(settings.GymDescriptionCollectionName);
        }

        public Task<bool> Create(GymDescription model)
        {
            throw new NotImplementedException();
        }

        public GymDescription GetGymDescriptionByGymID(Guid gymID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GymDescription model, Guid id)
        {
            throw new NotImplementedException();
        }

        GymDescription ICollectionService<GymDescription>.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<GymDescription>> ICollectionService<GymDescription>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
