using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Settings.GymTrainings
{
    public class MongoDBSettingsGymsTrainings: IMongoDBSettingsGymsTrainings
    {
        public string  GymTrainingsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
