using CoreApplication.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplication.Interfaces.IRepositories
{
   public  interface IContactRepository
    {
        IQueryable<Contact> Entities { get; }
        Task<List<Contact>> GetListAsync();
        Task<Contact> GetByIdAsync(long id);
        Task<Contact> InsertAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
    }
}
