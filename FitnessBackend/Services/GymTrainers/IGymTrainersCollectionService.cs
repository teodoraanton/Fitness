using FitnessBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public interface IGymTrainersCollectionService: ICollectionService<GymTrainers>
    {
        List<GymTrainers> GetGymTrainersByGymID(Guid gymID);
    }
}
