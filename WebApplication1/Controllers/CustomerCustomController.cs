using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCustomController : ControllerBase
    {
        private readonly MyDataContext _context;

        public CustomerCustomController(MyDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Customer> GetProductsListFilterNameOrLastName(string value)
        {
            var response = _context.Customers
                .Where(x => x.FirstName.Contains(value) || x.LastName.Contains(value))
                .OrderByDescending(x => x.LastName)
                .ToList();

            return response;
        }
    }
}
