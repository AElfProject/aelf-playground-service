using Volo.Abp.Modularity;

namespace AElf.Playground;

[DependsOn(
    typeof(PlaygroundApplicationModule),
    typeof(PlaygroundDomainTestModule)
)]
public class PlaygroundApplicationTestModule : AbpModule
{

}
