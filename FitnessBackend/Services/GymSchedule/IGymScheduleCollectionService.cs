using FitnessBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public interface IGymScheduleCollectionService: ICollectionService<GymSchedule>
    {
        List<GymSchedule> GetGymScheduleByGymID(Guid gymID);
        Task<List<GymSchedule>> GetGymScheduleByGymIDAndDay(Guid gymID, String day);
    }
}
