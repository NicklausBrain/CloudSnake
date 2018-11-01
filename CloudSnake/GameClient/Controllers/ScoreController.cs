using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using GameDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace GameClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IGameDataService gameData;

        public ScoreController()
        {
            this.gameData = ServiceProxy.Create<IGameDataService>(
                new Uri("fabric:/CloudSnake/GameData"),
                new ServicePartitionKey(0));
        }

        [HttpGet]
        public async Task<IEnumerable<Score>> Get()
        {
            var res =await this.gameData.GetScores();

            return res.AsEnumerable();
        }

        [HttpPost]
        public async Task Post(Score score)
        {
            await this.gameData.AddScore(score);
        }
    }
}
