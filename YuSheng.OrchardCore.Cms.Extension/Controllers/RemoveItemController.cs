using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Notify;
using System.Threading.Tasks;

namespace YuSheng.OrchardCore.Cms.Extension.Controllers
{
    public class AdminController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly INotifier _notifier;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHtmlLocalizer<AdminController> H;

        public AdminController(IContentManager contentManager,
      IContentDefinitionManager contentDefinitionManager,
      INotifier notifier,
      ILogger<AdminController> logger,
      IHtmlLocalizer<AdminController> htmlLocalizer,
      IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _notifier = notifier;
            _contentManager = contentManager;
            _contentDefinitionManager = contentDefinitionManager;
            H = htmlLocalizer;
            Logger = (ILogger)logger;
        }

        public ILogger Logger { get; set; }

        public async Task<IActionResult> RemoveItem(
          string contentItemId,
          string returnUrl)
        {

            ContentItem contentItem = await _contentManager.GetAsync(contentItemId, VersionOptions.Latest);

            if (!await _authorizationService.AuthorizeAsync(User, Permissions.RemoveItem))
            {
                return Forbid();
            }

            if (contentItem != null)
            {
                ContentTypeDefinition typeDefinition = _contentDefinitionManager.GetTypeDefinition(contentItem.ContentType);
                await _contentManager.RemoveAsync(contentItem);
                LocalizedHtmlString message;
                if (!string.IsNullOrWhiteSpace(typeDefinition.DisplayName))
                    message = H["That {0} has been removed.", new object[1]
                    {
                        typeDefinition.DisplayName
                    }];
                else
                    message = H["That content has been removed."];
                await _notifier.SuccessAsync(message);
            }

            return Url.IsLocalUrl(returnUrl) ? LocalRedirect(returnUrl) : (IActionResult)RedirectToAction("List", "Admin", (object)new
            {
                area = "OrchardCore.Contents"
            });

        }
    }
}
