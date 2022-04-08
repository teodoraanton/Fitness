using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessBackend.Settings;

namespace FitnessBackend.Settings
{
    public class MongoDBSettingsGymPrices: IMongoDBSettingsGymPrices
    {
        public string GymPricesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
