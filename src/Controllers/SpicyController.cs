using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotnetos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpicyController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public string Get()
        {
            return "Hot!";
        }
    }
}
