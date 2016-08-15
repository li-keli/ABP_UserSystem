using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.PagedResult;
using Cbd.Fgw.Application.System.Menu.Dto;

namespace Cbd.Fgw.Application.System.Role.Dto {
    public class RoleDtoOutput : IOutputDto {
        [Display(Name = "编号")]
        public string Id { set; get; }
    }

    [AutoMap(typeof(Core.System.Role))]
    public class RoleSearchDtoOutput : RoleDtoOutput, IDataTableViewModelOutput<RoleDto> {
        public int Total { get; set; }
        public List<RoleDto> Rows { get; set; }
    }

    [AutoMap(typeof(Core.System.Role))]
    public class RoleAuthorizationOutput : RoleDtoOutput {
        public RoleAndMenuDtoOutput RoleDto { set; get; }
        public List<MenuDto> MenuDtos { set; get; }
    }

    [AutoMap(typeof(Core.System.Role))]
    public class RoleAndMenuDtoOutput : RoleDtoOutput {
        [Display(Name = "角色名称")]
        public string RoleName { set; get; }
        [Display(Name = "是否系统角色")]
        public bool IsSystem { set; get; }
        [Display(Name = "角色描述")]
        public string Describe { set; get; }
        [Display(Name = "模块")]
        public virtual ICollection<MenuDto> Menus { set; get; }
    }
}
