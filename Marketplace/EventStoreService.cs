using EventStore.ClientAPI;
using Marketplace.Infrastructure;

namespace Marketplace
{
    public class EventStoreService : IHostedService
    {
        private readonly IEventStoreConnection _esConnection;
        private readonly ProjectionManager _projectionManager;

        public EventStoreService(IEventStoreConnection esConnection, ProjectionManager projectionManager)
        {
            _esConnection = esConnection;
            _projectionManager = projectionManager;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _esConnection.ConnectAsync();
            await _projectionManager.Start();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _projectionManager.Stop();
            _esConnection.Close();

            return Task.CompletedTask;
        }
    }
}