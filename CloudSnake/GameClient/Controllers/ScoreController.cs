using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDomain;
using Microsoft.AspNetCore.Mvc;

namespace GameClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private static List<Score> scores = new List<Score>();

        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return scores;
        }

        [HttpPost]
        public void Post(Score score)
        {
            scores.Add(score);
        }
    }
}
