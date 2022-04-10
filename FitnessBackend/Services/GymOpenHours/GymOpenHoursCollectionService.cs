using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymOpenHoursCollectionService : IGymOpenHoursCollectionService
    {
        private readonly IMongoCollection<GymOpenHours> _gymsOpenHours;

        public GymOpenHoursCollectionService(IMongoDBSettingsGymOpenHours settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gymsOpenHours = database.GetCollection<GymOpenHours>(settings.GymOpenHoursCollectionName);
        }
        public async Task<bool> Create(GymOpenHours model)
        {
            model.Id = new Guid();
            await _gymsOpenHours.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gymsOpenHours.DeleteOneAsync(gymOpenHour => gymOpenHour.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public GymOpenHours Get(Guid id)
        {
            var filter = Builders<GymOpenHours>.Filter.Eq(f => f.Id, id);
            return _gymsOpenHours.Find(filter).FirstOrDefault();
        }

        public async Task<List<GymOpenHours>> GetAll()
        {
            var result = await _gymsOpenHours.FindAsync(gymOpenHour => true);

            return result.ToList();
        }

        public List<GymOpenHours> GetGymOpenHoursByGymID(Guid gymID)
        {
            var filter = Builders<GymOpenHours>.Filter.Eq(f => f.GymID, gymID);
            return _gymsOpenHours.Find(filter).ToList();
        }

        public async Task<bool> Update(GymOpenHours model, Guid id)
        {
            model.Id = id;
            var result = await _gymsOpenHours.ReplaceOneAsync(gymOpenHour => gymOpenHour.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gymsOpenHours.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
