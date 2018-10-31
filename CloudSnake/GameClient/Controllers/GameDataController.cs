using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameClient.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameDataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<int> Score()
        {
            return Enumerable.Range(0, 100);
        }
    }
}
