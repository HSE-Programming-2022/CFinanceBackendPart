using System.Net;
using AutoMapper;
using CFinance.Context.Models;
using CFinance.WebAPI.Models;
using CFinance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CFinance.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PortfolioController : Controller
    {
        private IMapper _mapper;

        public PortfolioController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PortfolioResponse>> GetUserPortfolios(int uid)
        {
            var portfolios = PortfolioService.GetPorfolioForUser(uid);

            List<PortfolioResponse> result = portfolios.Select(x => _mapper.Map<PortfolioResponse>(x)).ToList();

            return result;
        }

        [HttpPost]
        public IActionResult CreatePortfolioForUser(int uid)
        {
            try
            {
                int newPortfolioId = PortfolioService.CreatePortfolioForUser(uid);

                return Ok(newPortfolioId);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]

        public IActionResult AddToPortfolio(int pid, string ticker)
        {
            PortfolioService.AddPositionToPortfolio(ticker, pid);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFromPortfolio(int pid, string ticker)
        {
            PortfolioService.DeletePositionFromPortfolio(ticker, pid);

            return Ok();
        }
    }
}
