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
        public IActionResult CreatePortfolioForUser(CreatePortfolioRequest uidRequest)
        {
            int uid = uidRequest.uid;
            string name = uidRequest.name;

            try
            {
                int newPortfolioId = PortfolioService.CreatePortfolioForUser(uid, name);

                return Ok(newPortfolioId);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]

        public IActionResult AddToPortfolio(PositionEditRequest request)
        {
            PortfolioService.AddPositionToPortfolio(request.ticker, request.pid);

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
