using PruebaNet8.Business.Interfaces;
using PruebaNet8.Data;
using PruebaNet8.Data.Models;

namespace PruebaNet8.Business.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly PruebaNet8DbContext _dbContext;

        public InvoiceDetailService(PruebaNet8DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InvoiceDetail>> GetDetails()
        {
            return _dbContext.InvoiceDetails.ToList();
        }

        public async Task<InvoiceDetail> GetDetail(int id)
        {
            return await _dbContext.InvoiceDetails.FindAsync(id);
        }

        public async Task<InvoiceDetail> CreateDetail(InvoiceDetail invoiceDetail)
        {
            _dbContext.InvoiceDetails.AddAsync(invoiceDetail);
            await _dbContext.SaveChangesAsync();
            return invoiceDetail;
        }

        public async Task<InvoiceDetail> UpdateDetail(InvoiceDetail invoiceDetail)
        {
            _dbContext.InvoiceDetails.Update(invoiceDetail);
            await _dbContext.SaveChangesAsync();
            return invoiceDetail;
        }

        public async Task DeleteDetail(int id)
        {
            var invoiceDetail = await GetDetail(id);
            _dbContext.InvoiceDetails.Remove(invoiceDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
