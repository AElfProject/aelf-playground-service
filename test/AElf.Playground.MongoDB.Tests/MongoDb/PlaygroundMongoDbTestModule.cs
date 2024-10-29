using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace AElf.Playground.MongoDB;

[DependsOn(
    typeof(PlaygroundApplicationTestModule),
    typeof(PlaygroundMongoDbModule)
)]
public class PlaygroundMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = PlaygroundMongoDbFixture.GetRandomConnectionString();
        });
    }
}
