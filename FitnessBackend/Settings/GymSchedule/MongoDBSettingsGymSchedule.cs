using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Settings.GymSchedule
{
    public class MongoDBSettingsGymSchedule: IMongoDBSettingsGymSchedule
    {
        public string GymScheduleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
