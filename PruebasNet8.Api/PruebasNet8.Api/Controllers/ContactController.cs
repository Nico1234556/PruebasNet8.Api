using Microsoft.AspNetCore.Mvc;
using PruebaNet8.Business.Interfaces;
using PruebaNet8.Data.Models;

namespace PruebasNet8.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactService.GetContacts();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            var newContact = await _contactService.CreateContact(contact);
            return Ok(newContact);
        }

    }
}
