using Volo.Abp.Modularity;

namespace AElf.Playground;

[DependsOn(
    typeof(PlaygroundDomainModule),
    typeof(PlaygroundTestBaseModule)
)]
public class PlaygroundDomainTestModule : AbpModule
{

}
