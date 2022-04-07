using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class CityCollectionService : ICityCollectionService
    {
        private readonly IMongoCollection<City> _cities;

        public CityCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cities = database.GetCollection<City>(settings.CitiesCollectionName);
        }
        public async Task<bool> Create(City model)
        {
            model.Id = new Guid();
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

        public City Get(Guid id)
        {
            var filter = Builders<City>.Filter.Eq(f => f.Id, id);
            return _cities.Find(filter).FirstOrDefault();
        }

        public async Task<List<City>> GetAll()
        {
            var result = await _cities.FindAsync(city => true);

            return result.ToList();
        }

        public async Task<bool> Update(City model, Guid id)
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
