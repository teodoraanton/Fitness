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
        public async Task<bool> Create(GymTrainers model)
        {
            model.Id = new Guid();
            await _gymsTrainers.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gymsTrainers.DeleteOneAsync(gymTrainers => gymTrainers.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public GymTrainers Get(Guid id)
        {
            var filter = Builders<GymTrainers>.Filter.Eq(f => f.Id, id);
            return _gymsTrainers.Find(filter).FirstOrDefault();
        }

        public async Task<List<GymTrainers>> GetAll()
        {
            var result = await _gymsTrainers.FindAsync(gymTrainers => true);

            return result.ToList();
        }

        public List<GymTrainers> GetGymTrainersByGymID(Guid gymID)
        {
            var filter = Builders<GymTrainers>.Filter.Eq(f => f.GymID, gymID);
            return _gymsTrainers.Find(filter).ToList();
        }

        public async Task<bool> Update(GymTrainers model, Guid id)
        {
            model.Id = id;
            var result = await _gymsTrainers.ReplaceOneAsync(gymTrainers => gymTrainers.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gymsTrainers.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
