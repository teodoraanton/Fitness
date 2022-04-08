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
        public Task<bool> Create(GymPrices model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public GymPrices Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymPrices>> GetAll()
        {
            throw new NotImplementedException();
        }

        public GymPrices GetGymPricesByGymID(Guid gymID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GymPrices model, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
