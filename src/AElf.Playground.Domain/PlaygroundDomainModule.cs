using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AElf.Playground.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.SettingManagement;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Caching;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.AspNetCore.Mvc.Dapr.EventBus;
using Volo.Abp.BlobStoring.Aws;
using Volo.Abp.BlobStoring;
using Microsoft.Extensions.Configuration;

namespace AElf.Playground;

[DependsOn(
    typeof(PlaygroundDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpCachingModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpEmailingModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpOpenIddictDomainModule),
    typeof(BlobStoringDatabaseDomainModule)
    )]
[DependsOn(typeof(AbpAspNetCoreMvcDaprEventBusModule))]
[DependsOn(typeof(AbpBlobStoringAwsModule))]
public class PlaygroundDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
        });

        var configuration = context.Services.GetConfiguration();

        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureDefault(container =>
            {
                // https://abp.io/docs/latest/framework/infrastructure/blob-storing/aws
                container.UseAws(Aws =>
                {
                    // https://stackoverflow.com/a/70843145
                    Aws.AccessKeyId = configuration.GetSection("Aws:AccessKeyId").Value;
                    Aws.SecretAccessKey = configuration.GetSection("Aws:SecretAccessKey").Value;
                    Aws.UseCredentials = configuration.GetSection("Aws:UseCredentials").Get<bool>();
                    Aws.UseTemporaryCredentials = configuration.GetSection("Aws:UseTemporaryCredentials").Get<bool>();
                    Aws.UseTemporaryFederatedCredentials = configuration.GetSection("Aws:UseTemporaryFederatedCredentials").Get<bool>();
                    Aws.ProfileName = configuration.GetSection("Aws:ProfileName").Value;
                    Aws.ProfilesLocation = configuration.GetSection("Aws:ProfilesLocation").Value;
                    Aws.Region = configuration.GetSection("Aws:Region").Value ?? "default";
                    Aws.Name = configuration.GetSection("Aws:Name").Value ?? "default";
                    Aws.Policy = configuration.GetSection("Aws:Policy").Value;
                    Aws.DurationSeconds = configuration.GetSection("Aws:DurationSeconds").Get<int>();
                    Aws.ContainerName = configuration.GetSection("Aws:ContainerName").Value;
                    Aws.CreateContainerIfNotExists = configuration.GetSection("Aws:CreateContainerIfNotExists").Get<bool>();
                });
            });
        });


#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
