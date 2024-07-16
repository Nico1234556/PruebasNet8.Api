using PruebaNet8.Data.Models;

namespace PruebaNet8.Business.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int id);
        Task<Invoice> CreateInvoice(Invoice invoice );
        Task<Invoice> UpdateInvoice(Invoice invoice);
        Task DeleteInvoice(int id);
    }
}
