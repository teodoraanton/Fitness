using FitnessBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public interface IGymsCollectionService: ICollectionService<Gyms>
    {
        Task<List<Gyms>> GetGymsByCityName(Guid city);
    }
}
