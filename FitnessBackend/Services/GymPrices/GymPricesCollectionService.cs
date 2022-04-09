using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymPricesCollectionService : IGymPricesCollectionService
    {
        private readonly IMongoCollection<GymPrices> _gymsPrices;

        public GymPricesCollectionService(IMongoDBSettingsGymPrices settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gymsPrices = database.GetCollection<GymPrices>(settings.GymPricesCollectionName);
        }
        public async Task<bool> Create(GymPrices model)
        {
            model.Id = new Guid();
            await _gymsPrices.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gymsPrices.DeleteOneAsync(gymPrices => gymPrices.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public GymPrices Get(Guid id)
        {
            var filter = Builders<GymPrices>.Filter.Eq(f => f.Id, id);
            return _gymsPrices.Find(filter).FirstOrDefault();
        }

        public async Task<List<GymPrices>> GetAll()
        {
            var result = await _gymsPrices.FindAsync(gymPrices => true);

            return result.ToList();
        }

        public List<GymPrices> GetGymPricesByGymID(Guid gymID)
        {
            var filter = Builders<GymPrices>.Filter.Eq(f => f.GymID, gymID);
            return _gymsPrices.Find(filter).ToList();
        }

        public async Task<bool> Update(GymPrices model, Guid id)
        {
            model.Id = id;
            var result = await _gymsPrices.ReplaceOneAsync(gymPrices => gymPrices.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gymsPrices.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
