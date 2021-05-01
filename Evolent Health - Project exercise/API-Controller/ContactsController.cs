using CoreApplication.Entities;
using CoreApplication.Interfaces.IRepositories;
using Evolent_Health___Project_exercise.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Evolent_Health___Project_exercise.API_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactRepository.GetListAsync());
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _contactRepository.GetByIdAsync(id));
        }

        [HttpPost("createContact")]
        public async Task<IActionResult> CreateContact(ContactModel contact)
        {
            contact.Status = true;
            if (contact.Id == 0)
                return Ok(await _contactRepository.InsertAsync(new Contact
                {
                    Email = contact.Email,
                    LastName = contact.LastName,
                    FirstName = contact.FirstName,
                    PhoneNumber = contact.PhoneNumber,
                    Status = contact.Status
                }));
            else
            {
                var contactDetail = await _contactRepository.GetByIdAsync(contact.Id);
                if (contactDetail != null)
                {
                    contactDetail.Email = contact.Email;
                    contactDetail.LastName = contact.LastName;
                    contactDetail.FirstName = contact.FirstName;
                    contactDetail.PhoneNumber = contact.PhoneNumber;
                    contactDetail.Status = contact.Status;
                    return Ok(await _contactRepository.UpdateAsync(contactDetail));
                }
                return Ok(contact);
            }

        }

        [HttpGet("deleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var contactDetail = await _contactRepository.GetByIdAsync(id);
            if (contactDetail != null)
            {
                contactDetail.Status = false;
                return Ok(await _contactRepository.UpdateAsync(contactDetail));
            }
            return Ok();
        }
    }
}
