using PruebaNet8.Data.Models;

namespace PruebaNet8.Business.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task DeleteContact(int id);
    }
}
