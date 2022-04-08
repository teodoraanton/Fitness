using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Settings.GymTrainings
{
    public interface IMongoDBSettingsGymsTrainings
    {
        string GymTrainingsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
