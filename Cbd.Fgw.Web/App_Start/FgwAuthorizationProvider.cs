using Abp.Authorization;

namespace Cbd.Fgw.Web {
    /// <summary>
    /// 操作权限
    /// </summary>
    public class FgwAuthorizationProvider : AuthorizationProvider {
        public override void SetPermissions(IPermissionDefinitionContext context) {
            var administration = context.CreatePermission("Administration");

            var userManagement = administration.CreateChildPermission("Administration.UserManagement");
            userManagement.CreateChildPermission("Administration.UserManagement.CreateUser");

            var roleManagement = administration.CreateChildPermission("Administration.RoleManagement");
        }
    }
}