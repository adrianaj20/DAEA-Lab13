using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceCustomController : ControllerBase
    {
        private readonly MyDataContext _context;

        public InvoiceCustomController(MyDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Invoice> GetInvoicesByCustomerName(string customerName)
        {
            var response = _context.Invoices
                .Include(x => x.Customer)
                //.Where(x => x.Customer.FirstName == customerName)
                .Where(x => x.Customer.FirstName.Contains(customerName))
                .OrderByDescending(i => i.Customer.FirstName)
                .ToList();

            return response;
        }
    }
}
