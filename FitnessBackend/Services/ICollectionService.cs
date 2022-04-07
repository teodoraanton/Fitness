using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBackend.Services
{
    public interface ICollectionService<T>
    {
        Task<List<T>> GetAll();
        T Get(Guid id);
        Task<bool> Create(T model);
        Task<bool> Update(T model, Guid id);
        Task<bool> Delete(Guid id);
    }
}
