using Microsoft.Extensions.DependencyInjection;
using LazyAbp.ReviewKit.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace LazyAbp.ReviewKit.Blazor
{
    [DependsOn(
        typeof(ReviewKitHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ReviewKitBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ReviewKitBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ReviewKitBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new ReviewKitMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(ReviewKitBlazorModule).Assembly);
            });
        }
    }
}