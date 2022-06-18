using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CFinance.Context.Models;
using CFinance.WebAPI.Models;
using CFinance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace CFinance.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;

        public CompanyController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{ticker}")]
        public ActionResult<CompanyResponse> Get(string ticker)
        {
            var company = CompanyService.Get(ticker);

            if (company == null)
                return NotFound();

            var companyDTOMapped = _mapper.Map<CompanyResponse>(company);

            return companyDTOMapped;
        }

        [HttpGet]
        public ActionResult<List<CompanyResponse>> GetAll()
        {
           List<Company> allCompanies = CompanyService.GetAll();

           return allCompanies.Select(x => _mapper.Map<CompanyResponse>(x)).ToList();
        }
    }
}
