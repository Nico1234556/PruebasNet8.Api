using PruebaNet8.Data.Models;

namespace PruebaNet8.Business.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoiceDetail>> GetDetails();
        Task<InvoiceDetail> GetDetail(int id);
        Task<InvoiceDetail> CreateDetail(InvoiceDetail invoiceDetail);
        Task<InvoiceDetail> UpdateDetail(InvoiceDetail invoiceDetail);
        Task DeleteDetail(int id);
    }
}
