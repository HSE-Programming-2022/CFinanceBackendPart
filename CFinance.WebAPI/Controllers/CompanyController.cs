using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CFinance.Context.Models;
using CFinance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace CFinance.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        [HttpGet("{ticker}")]
        public ActionResult<Company> Get(string ticker)
        {
            var company = CompanyService.Get(ticker);

            if (company == null)
                return NotFound();

            return company;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAll() => CompanyService.GetAll();
    }
}
