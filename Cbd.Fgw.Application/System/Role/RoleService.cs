using Abp.UI;
using AutoMapper;
using System.Linq;
using Abp.AutoMapper;
using Abp.Authorization;
using Castle.Core.Internal;
using Cbd.Fgw.Core.IRepository;
using System.Collections.Generic;
using Abp.Collections.Extensions;
using Cbd.Fgw.Application.System.Menu;
using Cbd.Fgw.Application.System.Role.Dto;

namespace Cbd.Fgw.Application.System.Role {
    public class RoleService : FgwAppServiceBase, IRoleService {
        private readonly IRoleRepository _roleRepository;
        private readonly IMenuService _menuService;
        private readonly IPermissionManager _permissionManager;

        public RoleService(IRoleRepository roleRepository, IMenuService menuService, IPermissionManager permissionManager) {
            _roleRepository = roleRepository;
            _menuService = menuService;
            _permissionManager = permissionManager;
        }

        public List<RoleDto> GetAll(RoleDto input) {
            Logger.Info($"执行查询角色动作");
            var data = _roleRepository.GetAll();
            var roles = input.Id != 0 ? data.Where(r => r.Id == input.Id).ToList() : data.ToList();
            Mapper.CreateMap<Core.System.Role, RoleDto>();
            return roles.MapTo<List<RoleDto>>();
        }

        public RoleDto Get(RoleDto input) {
            var role = _roleRepository.Get(input.Id);
            Mapper.CreateMap<Core.System.Role, RoleDto>();
            return role.MapTo<RoleDto>();
        }

        public RoleSearchDtoOutput GetAll(RoleSearchDtoInput input) {
            if (input == null) {
                input = new RoleSearchDtoInput();
            }

            Logger.Info(" 查询角色信息，查询内容： " + input);
            var roleall = _roleRepository.GetAllList();
            var total = roleall.Count;
            roleall.WhereIf(!string.IsNullOrWhiteSpace(input.RoleName), r => r.RoleName.Contains(input.RoleName));
            if (roleall == null) {
                throw new UserFriendlyException("未查询到数据。");
            }
            Mapper.CreateMap<Core.System.Role, RoleDto>();
            var rows = roleall.MapTo<List<RoleDto>>();
            rows = rows.Skip(input.Offset).Take(input.Limit).ToList();

            return new RoleSearchDtoOutput { Total = total, Rows = rows };
        }

        public RoleAndMenuDtoOutput GetAndMenu(int id) {
            var role = _roleRepository.GetAndMenu(id);
            Mapper.CreateMap<Core.System.Role, RoleAndMenuDtoOutput>();

            return role.MapTo<RoleAndMenuDtoOutput>();
        }

        public void CreateRole(RoleCreateInput input) {
            Logger.Info($"创建角色,{input.RoleName}");
            var role = input.MapTo<Core.System.Role>();
            _roleRepository.Insert(role);
        }

        public void EditRole(RoleCreateInput input) {
            Logger.Info($"更新角色,{input.RoleName}");
            
            var role = input.MapTo<Core.System.Role>();
            _roleRepository.Update(role);
        }

        public void DeleteRole(int id) {
            Logger.Info($"删除角色,{id}");
            _roleRepository.Delete(r => r.Id == id);
        }

        public void SetAuthorization(RoleAuthorizationInput input) {
            Logger.Info($"角色授权");
            var role = _roleRepository.GetAndMenu(input.Id);
            role.Menus = new List<Core.System.Menu>();
            if (input.Menus.Count > 0) {
                input.Menus.ForEach(m => {
                    role.Menus.Add(_menuService.GetMenu(m.Id));
                });
            }

        }
    }
}
