using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Liquid;
using YuSheng.OrchardCore.Cms.Extension.Drivers;
using YuSheng.OrchardCore.Cms.Extension.Liquid;

namespace OrchardCore.ContentPreview
{
    public class Startup : Modules.StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddLiquidFilter<EditorUrlFilter>("editor_url");
            services.AddScoped<IContentDisplayDriver, RemoveItemDriver>();
        }
    }
}
