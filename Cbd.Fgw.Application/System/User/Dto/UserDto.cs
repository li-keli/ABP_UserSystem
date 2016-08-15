using Abp.AutoMapper;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Cbd.Fgw.Application.System.Department.Dto;
using Cbd.Fgw.Application.System.Role.Dto;

namespace Cbd.Fgw.Application.System.User.Dto {

    [AutoMap(typeof(Core.System.User))]
    public class UserDto : EntityDto {
        [Display(Name = "登录帐号")]
        public string UserName { set; get; }

        [Display(Name = "真实姓名")]
        public string RealName { set; get; }

        [Display(Name = "是否启用")]
        public bool IsActive { set; get; }

        [Display(Name = "是否系统帐号")]
        public bool IsSystem { set; get; }

        [Display(Name = "部门")]
        public int DepartmentId { set; get; }

        [Display(Name = "角色")]
        public List<RoleDto> Roles { set; get; }
        public DepartmentBaseDto Department { set; get; }
    }
}
