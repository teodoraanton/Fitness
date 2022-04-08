using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymTrainingsCollectionService : IGymTrainingsCollectionService
    {
        private readonly IMongoCollection<GymTrainings> _gymsTrainings;

        public GymTrainingsCollectionService(IMongoDBSettingsGymTrainings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gymsTrainings = database.GetCollection<GymTrainings>(settings.GymTrainingsCollectionName);
        }
        public Task<bool> Create(GymTrainings model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public GymTrainings Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymTrainings>> GetAll()
        {
            throw new NotImplementedException();
        }

        public GymTrainings GetGymTrainingsByGymID(Guid gymID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GymTrainings model, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
