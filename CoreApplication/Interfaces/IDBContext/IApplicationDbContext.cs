using CoreApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.Interfaces.IDBContext
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; set; }
    }
}
