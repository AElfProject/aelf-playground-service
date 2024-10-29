using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace AElf.Playground.Data;

public class PlaygroundDbMigrationService : ITransientDependency
{
    public ILogger<PlaygroundDbMigrationService> Logger { get; set; }

    private readonly IDataSeeder _dataSeeder;
    private readonly IEnumerable<IPlaygroundDbSchemaMigrator> _dbSchemaMigrators;

    public PlaygroundDbMigrationService(
        IDataSeeder dataSeeder,
        IEnumerable<IPlaygroundDbSchemaMigrator> dbSchemaMigrators)
    {
        _dataSeeder = dataSeeder;
        _dbSchemaMigrators = dbSchemaMigrators;

        Logger = NullLogger<PlaygroundDbMigrationService>.Instance;
    }

    public async Task MigrateAsync()
    {

        Logger.LogInformation("Started database migrations...");

        await MigrateDatabaseSchemaAsync();
        await SeedDataAsync();

        Logger.LogInformation($"Successfully completed host database migrations.");

        Logger.LogInformation("Successfully completed all database migrations.");
        Logger.LogInformation("You can safely end this process...");
    }

    private async Task MigrateDatabaseSchemaAsync()
    {
        Logger.LogInformation(
            $"Migrating schema for host database...");

        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async Task SeedDataAsync()
    {
        Logger.LogInformation($"Executing host database seed...");

        await _dataSeeder.SeedAsync(new DataSeedContext()
            .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName,
                PlaygroundConsts.AdminEmailDefaultValue)
            .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName,
                PlaygroundConsts.AdminPasswordDefaultValue)
        );
    }

}
