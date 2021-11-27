using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace YuSheng.OrchardCore.Cms.Extension
{
    public class Permissions : IPermissionProvider
    {

        public static readonly Permission RemoveItem = new Permission(nameof(RemoveItem), "Remove Content Item");
        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(GetPermissions());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = GetPermissions()
                }
            };
        }

        private IEnumerable<Permission> GetPermissions()
        {
            return new[]
            {
                RemoveItem
            };
        }
    }

}
