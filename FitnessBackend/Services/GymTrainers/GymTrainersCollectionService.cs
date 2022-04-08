using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymTrainersCollectionService : IGymTrainersCollectionService
    {
        private readonly IMongoCollection<GymTrainers> _gymsTrainers;

        public GymTrainersCollectionService(IMongoDBSettingsGymTrainers settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gymsTrainers = database.GetCollection<GymTrainers>(settings.GymTrainersCollectionName);
        }
        public Task<bool> Create(GymTrainers model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public GymTrainers Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymTrainers>> GetAll()
        {
            throw new NotImplementedException();
        }

        public GymTrainers GetGymTrainersByGymID(Guid gymID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GymTrainers model, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
