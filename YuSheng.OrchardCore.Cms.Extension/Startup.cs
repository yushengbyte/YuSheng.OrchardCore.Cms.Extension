using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Liquid;
using OrchardCore.Modules;
using YuSheng.OrchardCore.Cms.Extension.Drivers;
using YuSheng.OrchardCore.Cms.Extension.Liquid;

namespace YuSheng.OrchardCore.Cms.Extension
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddLiquidFilter<EditorUrlFilter>("editor_url");
            services.AddScoped<IContentDisplayDriver, RemoveItemDriver>();
        }
    }
}
