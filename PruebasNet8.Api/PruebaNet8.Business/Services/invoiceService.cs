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

            existingInvoice.ClientName = invoice.ClientName;
            existingInvoice.ClientLastName = invoice.ClientLastName;
            existingInvoice.ClientPhone = invoice.ClientPhone;
            existingInvoice.ClientEmail = invoice.ClientEmail;
            existingInvoice.Total = invoice.Total;
            existingInvoice.Date = invoice.Date;

            
            _dbContext.InvoiceDetails.RemoveRange(existingInvoice.InvoiceDetailslist);
            existingInvoice.InvoiceDetailslist = invoice.InvoiceDetailslist;

            _dbContext.Invoices.Update(existingInvoice);
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
