using AElf.Playground.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AElf.Playground.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PlaygroundMongoDbModule),
    typeof(PlaygroundApplicationContractsModule)
)]
public class PlaygroundDbMigratorModule : AbpModule
{
}
