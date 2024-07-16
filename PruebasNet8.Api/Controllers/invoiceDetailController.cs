using Microsoft.AspNetCore.Mvc;
using PruebaNet8.Business.Interfaces;
using PruebaNet8.Data.Models;

namespace PruebasNet8.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            var invoiceDetails = await _invoiceDetailService.GetDetails();
            return Ok(invoiceDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail([FromBody] InvoiceDetail invoiceDetail)
        {
            var newInvoiceDetail = await _invoiceDetailService.CreateDetail(invoiceDetail);
            return Ok(newInvoiceDetail);
        }

    }
}
