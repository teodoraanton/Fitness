using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class CitiesCollectionService : ICitiesCollectionService
    {
        private readonly IMongoCollection<Cities> _cities;

        public CitiesCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cities = database.GetCollection<Cities>(settings.CitiesCollectionName);
        }
        public async Task<bool> Create(Cities model)
        {
            await _cities.InsertOneAsync(model);

            return true;
        }
        
        public async Task<bool> Delete(Guid id)
        {
            var result = await _cities.DeleteOneAsync(city => city.Id == id);
            if(!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Cities> Get(Guid id)
        {
            return (await _cities.FindAsync(city => city.Id == id)).FirstOrDefault();
        }

        public async Task<List<Cities>> GetAll()
        {
            var result = await _cities.FindAsync(city => true);

            return result.ToList();
        }

        public async Task<bool> Update(Cities model, Guid id)
        {
            model.Id = id;
            var result = await _cities.ReplaceOneAsync(city => city.Id == id, model);
            if(!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _cities.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
