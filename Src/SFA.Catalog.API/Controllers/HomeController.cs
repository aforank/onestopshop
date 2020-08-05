using Microsoft.AspNetCore.Mvc;

namespace SFA.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.Content("Hello World");
        }
    }
}
