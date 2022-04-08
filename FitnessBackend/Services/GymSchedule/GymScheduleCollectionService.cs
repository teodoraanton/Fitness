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

        public Task<bool> Create(GymSchedule model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public GymSchedule Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymSchedule>> GetAll()
        {
            throw new NotImplementedException();
        }

        public GymSchedule GetGymScheduleByGymID(Guid gymID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(GymSchedule model, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
