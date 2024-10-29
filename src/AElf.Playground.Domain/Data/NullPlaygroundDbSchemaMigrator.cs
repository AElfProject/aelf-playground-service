using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AElf.Playground.Data;

/* This is used if database provider does't define
 * IPlaygroundDbSchemaMigrator implementation.
 */
public class NullPlaygroundDbSchemaMigrator : IPlaygroundDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
