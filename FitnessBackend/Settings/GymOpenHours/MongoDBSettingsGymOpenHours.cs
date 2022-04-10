using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Settings
{
    public class MongoDBSettingsGymOpenHours : IMongoDBSettingsGymOpenHours
    {
        public string GymOpenHoursCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
