using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Interfaces.IRepositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);
    }
}
