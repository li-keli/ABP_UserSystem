using Abp.AutoMapper;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.PagedResult;
using System.ComponentModel.DataAnnotations;
using Cbd.Fgw.Application.System.Role.Dto;

namespace Cbd.Fgw.Application.System.Menu.Dto {
    [AutoMap(typeof(Core.System.Menu))]
    public class MenuDtoInput : IInputDto {
        [Display(Name = "编号")]
        public int Id { set; get; }
        [Display(Name = "菜单名称")]
        public string MenuName { set; get; }
        [Display(Name = "菜单链接")]
        public string MenuUrl { set; get; }
        [Display(Name = "菜单图标")]
        public string Icon { set; get; }
        [Display(Name = "是否为菜单组")]
        public bool IsMenuGroup { set; get; }
        [Display(Name = "父节点ID")]
        public int ParentMenuId { set; get; }
        [Display(Name = "描述")]
        public string Describe { set; get; }

        [Display(Name = "上级菜单")]
        public virtual MenuDto ParentMenu { set; get; }
        public virtual ICollection<RoleDto> Roles { set; get; }
    }

    [AutoMap(typeof(Core.System.Menu))]
    public class MenuSearchInputDto : MenuDtoInput, IDataTableViewModelInput {
        public string Order { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    [AutoMap(typeof(Core.System.Menu))]
    public class MenuCreateInputDto : MenuDtoInput {
    }

    [AutoMap(typeof(Core.System.Menu))]
    public class MenuEditInputDto : MenuDtoInput {
    }
}
