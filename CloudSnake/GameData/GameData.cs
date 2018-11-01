using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using GameDomain;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace GameData
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class GameData : StatefulService, IGameDataService
    {
        public GameData(StatefulServiceContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            var store = await this.StateManager.GetOrAddAsync<IReliableDictionary<Guid, IEnumerable<Score>>>("scores");

            var userId = Guid.Parse("a4d5a1d0-c034-4234-91d0-4e19d40ad294");

            using (var tr = this.StateManager.CreateTransaction())
            {
                var scores = await store.GetOrAddAsync(
                    tx: tr,
                    key: userId,
                    value: new Score[0]);

                return scores;
            }
        }

        public async Task AddScore(Score score)
        {
            var store = await this.StateManager.GetOrAddAsync<IReliableDictionary<Guid, IEnumerable<Score>>>("scores");

            var userId = Guid.Parse("a4d5a1d0-c034-4234-91d0-4e19d40ad294");

            using (var tr = this.StateManager.CreateTransaction())
            {
                await store.AddOrUpdateAsync(
                    tx: tr,
                    key: userId,
                    addValueFactory: guid => new[] { score },
                    updateValueFactory: (guid, enumerable) => enumerable.Append(score).ToArray());

                await tr.CommitAsync();
            }
        }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return this.CreateServiceRemotingReplicaListeners();
        }
    }
}
