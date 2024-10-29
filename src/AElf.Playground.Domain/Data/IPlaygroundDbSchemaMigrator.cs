using System.Threading.Tasks;

namespace AElf.Playground.Data;

public interface IPlaygroundDbSchemaMigrator
{
    Task MigrateAsync();
}
