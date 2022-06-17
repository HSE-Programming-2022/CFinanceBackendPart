using Microsoft.AspNetCore.Mvc;

namespace CFinance.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
