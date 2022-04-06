using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymsCollectionService : IGymsCollectionService
    {
        private readonly IMongoCollection<Gyms> _gyms;

        public GymsCollectionService(IMongoDBSettingsGyms settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gyms = database.GetCollection<Gyms>(settings.GymsCollectionName);
        }
        public async Task<bool> Create(Gyms model)
        {
            await _gyms.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gyms.DeleteOneAsync(gym => gym.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Gyms> Get(Guid id)
        {
            return (await _gyms.FindAsync(gym => gym.Id == id)).FirstOrDefault();
        }

        public async Task<List<Gyms>> GetAll()
        {
            var result = await _gyms.FindAsync(gym => true);

            return result.ToList();
        }

        public async Task<List<Gyms>> GetGymsByCityID(Guid cityID)
        {
            return (await _gyms.FindAsync(gym => gym.IDCity == cityID)).ToList();
        }

        public async Task<bool> Update(Gyms model, Guid id)
        {
            model.Id = id;
            var result = await _gyms.ReplaceOneAsync(gym => gym.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gyms.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
