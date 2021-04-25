using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        Task<T> GetItemById(object id);
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<int> Delete(object id);
    }
}
