using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using GameDomain;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace GameData
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class GameData : StatefulService
    {
        public GameData(StatefulServiceContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            var store = await this.StateManager.GetOrAddAsync<IReliableDictionary<Guid, IEnumerable<Score>>>(new Uri("scores"));

            using (var tr = this.StateManager.CreateTransaction())
            {
                var scores = await store.GetOrAddAsync(tr, Guid.Empty, Enumerable.Empty<Score>());

                return scores;
            }
        }

        public async Task AddScore(Score score)
        {
            var store = await this.StateManager.GetOrAddAsync<IReliableDictionary<Guid, IEnumerable<Score>>>(new Uri("scores"));

            using (var tr = this.StateManager.CreateTransaction())
            {
                await store.AddOrUpdateAsync(
                    tr,
                    Guid.Empty,
                    guid => new[] { score },
                    (guid, enumerable) => enumerable.Append(score));
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
            return new ServiceReplicaListener[0];
        }

      
        //protected override async Task RunAsync(CancellationToken cancellationToken)
        //{
        // TODO: Replace the following sample code with your own logic 
        //       or remove this RunAsync override if it's not needed in your service.

        //_repo = new ServiceFabricProductRepository(this.StateManager);

        //var myDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, long>>("myDictionary");

        //while (true)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();

        //    using (var tx = this.StateManager.CreateTransaction())
        //    {
        //        var result = await myDictionary.TryGetValueAsync(tx, "Counter");

        //        ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
        //            result.HasValue ? result.Value.ToString() : "Value does not exist.");

        //        await myDictionary.AddOrUpdateAsync(tx, "Counter", 0, (key, value) => ++value);

        //        // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
        //        // discarded, and nothing is saved to the secondary replicas.
        //        await tx.CommitAsync();
        //    }

        //    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        //}
        //}
    }
}
