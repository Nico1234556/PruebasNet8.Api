using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNet8.Data.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientLastName { get; set; }
        public string? ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public List<InvoiceDetail> InvoiceDetailslist { get; set; }

    }
}
