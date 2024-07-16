using PruebaNet8.Business.Interfaces;
using PruebaNet8.Data;
using PruebaNet8.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaNet8.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly PruebaNet8DbContext _dbContext;

        public InvoiceService(PruebaNet8DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Invoice>> GetInvoices()
        {
            return await _dbContext.Invoices.Include(i => i.InvoiceDetailslist).ToListAsync();
        }

        public async Task<Invoice> GetInvoice(int id)
        {
            return await _dbContext.Invoices.Include(i => i.InvoiceDetailslist).FirstOrDefaultAsync(i => i.InvoiceId == id);
        }

        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            if (invoice.InvoiceDetailslist != null && invoice.InvoiceDetailslist.Any())
            {
                foreach (var detail in invoice.InvoiceDetailslist)
                {
                    _dbContext.InvoiceDetails.Add(detail);
                }
            }

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> UpdateInvoice(Invoice invoice)
        {
            var existingInvoice = await _dbContext.Invoices.Include(i => i.InvoiceDetailslist).FirstOrDefaultAsync(i => i.InvoiceId == invoice.InvoiceId);

            if (existingInvoice == null)
            {
                return null;
            }

            _dbContext.Entry(existingInvoice).CurrentValues.SetValues(invoice);

            _dbContext.InvoiceDetails.RemoveRange(existingInvoice.InvoiceDetailslist);
            if (invoice.InvoiceDetailslist != null && invoice.InvoiceDetailslist.Any())
            {
                foreach (var detail in invoice.InvoiceDetailslist)
                {
                    _dbContext.InvoiceDetails.Add(detail);
                }
            }

            await _dbContext.SaveChangesAsync();
            return existingInvoice;
        }

        public async Task DeleteInvoice(int id)
        {
            var invoice = await GetInvoice(id);
            if (invoice != null)
            {
                _dbContext.Invoices.Remove(invoice);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
