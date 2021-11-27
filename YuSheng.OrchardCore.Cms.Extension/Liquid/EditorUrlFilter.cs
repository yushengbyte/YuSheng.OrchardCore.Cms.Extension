using Fluid;
using Fluid.Values;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.Liquid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YuSheng.OrchardCore.Cms.Extension.Liquid
{
    public class EditorUrlFilter: ILiquidFilter
    {
        private readonly IContentManager _contentManager;

        public EditorUrlFilter(IContentManager contentManager) => _contentManager = contentManager;

        public async ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, LiquidTemplateContext ctx)
        {
            if (!(input.ToObjectValue() is ContentItem objectValue))
                return NilValue.Instance;
            ContentItemMetadata contentItemMetadata = await _contentManager.PopulateAspectAsync<ContentItemMetadata>((IContent)objectValue);
            object obj;
            if (!ctx.AmbientValues.TryGetValue("UrlHelper", out obj))
                throw new ArgumentException("UrlHelper missing while invoking 'editor_url'");
            return new StringValue(((IUrlHelper)obj).RouteUrl(contentItemMetadata.EditorRouteValues));


        }
    }
}
