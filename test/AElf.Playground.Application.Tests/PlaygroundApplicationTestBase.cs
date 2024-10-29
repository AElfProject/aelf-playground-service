using Volo.Abp.Modularity;

namespace AElf.Playground;

public abstract class PlaygroundApplicationTestBase<TStartupModule> : PlaygroundTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
