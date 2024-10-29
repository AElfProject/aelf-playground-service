using Microsoft.Extensions.Localization;
using AElf.Playground.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AElf.Playground;

[Dependency(ReplaceServices = true)]
public class PlaygroundBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<PlaygroundResource> _localizer;

    public PlaygroundBrandingProvider(IStringLocalizer<PlaygroundResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
