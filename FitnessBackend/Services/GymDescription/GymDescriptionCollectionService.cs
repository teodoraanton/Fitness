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

        public async Task<bool> Create(GymDescription model)
        {
            model.Id = new Guid();
            await _gymsDescription.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gymsDescription.DeleteOneAsync(gymDescription => gymDescription.Id == id);
            if(!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public GymDescription GetGymDescriptionByGymID(Guid gymID)
        {
            var filter = Builders<GymDescription>.Filter.Eq(f => f.GymID, gymID);
            return _gymsDescription.Find(filter).FirstOrDefault();
        }

        public async Task<bool> Update(GymDescription model, Guid id)
        {
            model.Id = id;
            var result = await _gymsDescription.ReplaceOneAsync(gymDescription => gymDescription.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gymsDescription.InsertOneAsync(model);
                return false;
            }
            return true;
        }

        public GymDescription Get(Guid id)
        {
            var filter = Builders<GymDescription>.Filter.Eq(f => f.Id, id);
            return _gymsDescription.Find(filter).FirstOrDefault();
        }

        public async Task<List<GymDescription>> GetAll()
        {
            var result = await _gymsDescription.FindAsync(gymDescription => true);

            return result.ToList();
        }
    }
}
