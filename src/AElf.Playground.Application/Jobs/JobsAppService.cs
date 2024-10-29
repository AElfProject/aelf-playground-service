using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AElf.Playground.Jobs
{
    public class JobsAppService(
        JobManager jobManager) : ApplicationService
    {
        private readonly JobManager _jobManager = jobManager;

        public async Task CreateJobAsync(Guid id, string command)
        {
            if (command == "build")
            {
                await _jobManager.BuildAsync(id);
            }
            else if (command == "test")
            {
                await _jobManager.TestAsync(id);
            }
            else
            {
                throw new Exception($"Unknown command {command}.");
            }


        }

        public async Task<Stream> GetJobResponseAsync(Guid id)
        {
            return await _jobManager.GetResponseAsync(id);
        }
    }
}
