using Abp.AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.System.Role.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cbd.Fgw.Application.System.Menu.Dto {
    [JsonObject(MemberSerialization.OptOut)]
    [AutoMap(typeof(Core.System.Menu))]
    public class MenuDto : EntityDto {
        [Display(Name = "菜单名称")]
        public string MenuName { set; get; }
        [Display(Name = "菜单链接")]
        public string MenuUrl { set; get; }
        [Display(Name = "菜单图标")]
        public string Icon { set; get; }
        [Display(Name = "是否为菜单组")]
        public bool IsMenuGroup { set; get; }
        [Display(Name = "是否为根菜单")]
        public bool IsRoot { set; get; }
        [Display(Name = "上级菜单Id")]
        public int ParentMenuId { set; get; }
        [Display(Name = "描述")]
        [DataType(DataType.MultilineText)]
        public string Describe { set; get; }

        [JsonIgnore]
        [Display(Name = "上级菜单")]
        [ForeignKey("ParentMenuId")]
        public virtual MenuDto ParentMenu { set; get; }
        public virtual ICollection<RoleDto> Roles { set; get; }
    }
}
