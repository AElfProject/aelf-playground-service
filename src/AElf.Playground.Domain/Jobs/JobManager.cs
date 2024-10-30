// https://abp.io/docs/latest/framework/architecture/domain-driven-design/domain-services#domainservice-idomainservice
using System;
using System.IO;
using System.Threading.Tasks;
using AElf.Playground.Eto;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;

namespace AElf.Playground.Jobs
{
    public class JobManager(IDistributedEventBus distributedEventBus, IBlobContainer blobContainer) : DomainService
    {
        private readonly IDistributedEventBus _distributedEventBus = distributedEventBus;
        private readonly IBlobContainer _blobContainer = blobContainer;

        public async Task BuildAsync(Guid jobId)
        {
            await _distributedEventBus.PublishAsync(new JobRequestEto
            {
                Id = jobId,
                Command = "build",
            });
        }

        public async Task TestAsync(Guid jobId)
        {
            await _distributedEventBus.PublishAsync(new JobRequestEto
            {
                Id = jobId,
                Command = "test",
            });
        }

        public async Task<Stream> GetResponseAsync(Guid jobId)
        {
            return await _blobContainer.GetAsync(jobId.ToString());
        }
    }
}