using Microsoft.EntityFrameworkCore;
using PruebaNet8.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNet8.Data
{
    public class PruebaNet8DbContext : DbContext
    {
        public PruebaNet8DbContext(DbContextOptions<PruebaNet8DbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
