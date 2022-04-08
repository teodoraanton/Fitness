using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymCollectionService : IGymCollectionService
    {
        private readonly IMongoCollection<Gym> _gyms;

        public GymCollectionService(IMongoDBSettingsGym settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gyms = database.GetCollection<Gym>(settings.GymCollectionName);
        }
        public async Task<bool> Create(Gym model)
        {
            model.Id = new Guid();
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

        public Gym Get(Guid id)
        {
            var filter = Builders<Gym>.Filter.Eq(f => f.Id, id);
            return _gyms.Find(filter).FirstOrDefault();
        }

        public async Task<List<Gym>> GetAll()
        {
            var result = await _gyms.FindAsync(gym => true);

            return result.ToList();
        }

        public List<Gym> GetGymsByCityID(Guid city)
        {
            var filter = Builders<Gym>.Filter.Eq(f => f.CityID, city);
            return  _gyms.Find(filter).ToList();
        }

        public async Task<bool> Update(Gym model, Guid id)
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
