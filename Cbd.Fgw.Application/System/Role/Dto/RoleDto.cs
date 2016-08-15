using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Cbd.Fgw.Application.System.Role.Dto {
    [AutoMap(typeof(Core.System.Role))]
    public class RoleDto : EntityDto {
        [Display(Name = "角色名称")]
        public string RoleName { set; get; }
        [Display(Name = "是否系统角色")]
        public bool IsSystem { set; get; }
        [Display(Name = "角色描述")]
        public string Describe { set; get; }
    }
}
