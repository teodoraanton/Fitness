using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Settings
{
    public class MongoDBSettingsReservation : IMongoDBSettingsReservation
    {
        public string ReservationCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
