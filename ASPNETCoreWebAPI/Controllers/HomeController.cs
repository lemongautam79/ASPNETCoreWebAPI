using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                new
                {
                    Message = "Welcome to ASP.NET Core Web API 🚀",
                    Status = "Running"
                }
                );
        }
    }
}
