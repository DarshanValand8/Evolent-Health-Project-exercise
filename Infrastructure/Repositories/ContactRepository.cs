using CoreApplication.Entities;
using CoreApplication.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IRepositoryAsync<Contact> _repository;

        public IQueryable<Contact> Entities => _repository.Entities;

        public ContactRepository( IRepositoryAsync<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetListAsync()
        {
            return await _repository.Entities.Where(x => x.Status).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Contact> InsertAsync(Contact contact)
        {
            return await _repository.AddAsync(contact);
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            return await _repository.UpdateAsync(contact);
        }
    }
}
