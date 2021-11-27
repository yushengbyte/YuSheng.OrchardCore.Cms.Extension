using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.ViewModels;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace YuSheng.OrchardCore.Cms.Extension.Drivers
{
    public class RemoveItemDriver : ContentDisplayDriver
    {
        public override IDisplayResult Edit(ContentItem contentItem, IUpdateModel updater)
        {
            return Shape("RemoveItem_Button", new ContentItemViewModel(contentItem)).Location("Actions:after");
        }
    }
}
