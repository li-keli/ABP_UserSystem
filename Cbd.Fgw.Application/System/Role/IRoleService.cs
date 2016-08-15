using Abp.Application.Services;
using System.Collections.Generic;
using Cbd.Fgw.Application.System.Role.Dto;

namespace Cbd.Fgw.Application.System.Role {
    public interface IRoleService: IApplicationService
    {
        List<RoleDto> GetAll(RoleDto input);
        RoleDto Get(RoleDto input);
        void CreateRole(RoleCreateInput input);
        void EditRole(RoleCreateInput input);
        void DeleteRole(int id);
        /// <summary>
        /// 分页查询
        /// </summary>
        RoleSearchDtoOutput GetAll(RoleSearchDtoInput input);
        /// <summary>
        /// 获取Role包含Menu
        /// </summary>
        RoleAndMenuDtoOutput GetAndMenu(int id);
        /// <summary>
        /// 角色授权
        /// </summary>
        void SetAuthorization(RoleAuthorizationInput input);
    }
}