using Microsoft.AspNetCore.Mvc;

namespace Dotnetos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpicyController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hot!";
        }
    }
}