using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GameClient.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameDataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<int> Test()
        {
            return Enumerable.Range(0, 100);
        }
    }
}
