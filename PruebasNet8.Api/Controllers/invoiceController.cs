﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaNet8.Business.Interfaces;
using PruebaNet8.Data.Models;

namespace PruebasNet8.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceService.GetInvoices();
            return Ok(invoices);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            var newInvoice = await _invoiceService.CreateInvoice(invoice);
            return Ok(newInvoice);
        }
        //FALTA PUT DELETE 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
           var invoice = await _invoiceService.GetInvoice(id);
            await _invoiceService.DeleteInvoice(id);
            return Ok();
        }
    }
}
