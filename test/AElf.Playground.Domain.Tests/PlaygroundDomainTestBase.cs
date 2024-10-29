using Volo.Abp.Modularity;

namespace AElf.Playground;

/* Inherit from this class for your domain layer tests. */
public abstract class PlaygroundDomainTestBase<TStartupModule> : PlaygroundTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
