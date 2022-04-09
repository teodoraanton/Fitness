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
        public async Task<bool> Create(GymTrainings model)
        {
            model.Id = new Guid();
            await _gymsTrainings.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gymsTrainings.DeleteOneAsync(gymTrainings => gymTrainings.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public GymTrainings Get(Guid id)
        {
            var filter = Builders<GymTrainings>.Filter.Eq(f => f.Id, id);
            return _gymsTrainings.Find(filter).FirstOrDefault();
        }

        public async Task<List<GymTrainings>> GetAll()
        {
            var result = await _gymsTrainings.FindAsync(gym => true);

            return result.ToList();
        }

        public List<GymTrainings> GetGymTrainingsByGymID(Guid gymID)
        {
            var filter = Builders<GymTrainings>.Filter.Eq(f => f.GymID, gymID);
            return _gymsTrainings.Find(filter).ToList();
        }

        public async Task<bool> Update(GymTrainings model, Guid id)
        {
            model.Id = id;
            var result = await _gymsTrainings.ReplaceOneAsync(gymTrainings => gymTrainings.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gymsTrainings.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
