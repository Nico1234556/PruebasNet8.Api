using PruebaNet8.Business.Interfaces;
using PruebaNet8.Data;
using PruebaNet8.Data.Models;

namespace PruebaNet8.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly PruebaNet8DbContext _dbContext;

        public ContactService(PruebaNet8DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> GetContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _dbContext.Contacts.FindAsync(id);
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task DeleteContact(int id)
        {
            var contact = await GetContact(id);
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }
    }
}
