// https://abp.io/docs/latest/framework/infrastructure/event-bus/distributed#subscribing-to-events

using System.IO;
using System.Text;
using System.Threading.Tasks;
using AElf.Playground.Eto;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace AElf.Playground.Jobs
{
    public class JobResponseHandler(IBlobContainer blobContainer)
                : IDistributedEventHandler<JobResponseEto>,
          ITransientDependency
    {
        private readonly IBlobContainer _blobContainer = blobContainer;

        public async Task HandleEventAsync(JobResponseEto eventData)
        {
            string response = eventData.Response;
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            Stream stream = new MemoryStream(responseBytes);

            await _blobContainer.SaveAsync(eventData.Id.ToString(), stream);
        }
    }
}
