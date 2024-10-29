using AElf.Playground.Localization;
using Volo.Abp.Application.Services;

namespace AElf.Playground;

/* Inherit your application services from this class.
 */
public abstract class PlaygroundAppService : ApplicationService
{
    protected PlaygroundAppService()
    {
        LocalizationResource = typeof(PlaygroundResource);
    }
}
