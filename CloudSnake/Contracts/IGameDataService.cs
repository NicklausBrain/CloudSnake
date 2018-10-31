using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;
using GameDomain;

namespace Contracts
{
    public interface IGameDataService: IService
    {
        Task<IEnumerable<Score>> GetScores();

        Task AddScore(Score score);
    }
}
