using FitnessBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public interface IGymTrainingsCollectionService: ICollectionService<GymTrainings>
    {
        List<GymTrainings> GetGymTrainingsByGymID(Guid gymID);
    }
}
