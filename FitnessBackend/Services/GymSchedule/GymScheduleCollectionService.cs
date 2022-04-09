using FitnessBackend.Models;
using FitnessBackend.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public class GymScheduleCollectionService : IGymScheduleCollectionService
    {
        private readonly IMongoCollection<GymSchedule> _gymsSchedule;

        public GymScheduleCollectionService(IMongoDBSettingsGymSchedule settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _gymsSchedule = database.GetCollection<GymSchedule>(settings.GymScheduleCollectionName);
        }

        public async Task<bool> Create(GymSchedule model)
        {
            model.Id = new Guid();
            await _gymsSchedule.InsertOneAsync(model);

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _gymsSchedule.DeleteOneAsync(gymSchedule => gymSchedule.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public GymSchedule Get(Guid id)
        {
            var filter = Builders<GymSchedule>.Filter.Eq(f => f.Id, id);
            return _gymsSchedule.Find(filter).FirstOrDefault();
        }

        public async Task<List<GymSchedule>> GetAll()
        {
            var result = await _gymsSchedule.FindAsync(gymSchedule => true);

            return result.ToList();
        }

        public List<GymSchedule> GetGymScheduleByGymID(Guid gymID)
        {
            var filter = Builders<GymSchedule>.Filter.Eq(f => f.GymID, gymID);
            return _gymsSchedule.Find(filter).ToList();
        }

        public async Task<bool> Update(GymSchedule model, Guid id)
        {
            model.Id = id;
            var result = await _gymsSchedule.ReplaceOneAsync(gymSchedule => gymSchedule.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _gymsSchedule.InsertOneAsync(model);
                return false;
            }
            return true;
        }
    }
}
