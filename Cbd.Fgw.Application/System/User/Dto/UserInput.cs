using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.PagedResult;

namespace Cbd.Fgw.Application.System.User.Dto {
    public class UserInput : IInputDto {
        [Display(Name = "编号")]
        public int Id { set; get; }
    }

    [AutoMap(typeof(Core.System.User))]
    public class UserCreateInput : UserInput {
        [Required]
        [Display(Name = "登录帐号")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于{2}个字符并小于{1}个字符")]
        public string UserName { set; get; }

        [Required]
        [Display(Name = "真实姓名")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于{2}个字符并小于{1}个字符")]
        public string RealName { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Pwd { set; get; }

        [Required]
        [Compare("Pwd")]
        [DataType(DataType.Password)]
        [Display(Name = "再次输入密码")]
        public string PwdAgain { set; get; }

        [Display(Name = "是否启用")]
        public bool IsActive { set; get; }

        [Display(Name = "是否系统帐号")]
        public bool IsSystem { set; get; }

        [Display(Name = "部门")]
        public int DepartmentId { set; get; }

        [Display(Name = "角色")]
        public virtual ICollection<Core.System.Role> Roles { set; get; }
        public virtual Core.System.Department Department { set; get; }
    }

    [AutoMap(typeof(Core.System.User))]
    public class UserSearchInput : UserInput, IDataTableViewModelInput {
        [Display(Name = "登录帐号")]
        public string UserName { set; get; }
        [Display(Name = "真实姓名")]
        public string RealName { set; get; }

        public string Order { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    [AutoMap(typeof(Core.System.User))]
    public class UserUpdateInput : UserCreateInput {
    }

    [AutoMap(typeof(Core.System.User))]
    public class UserAuthorizationInput : UserInput {
        [Display(Name = "角色")]
        public virtual ICollection<Core.System.Role> Roles { set; get; }
    }

    public class UserChangeActiveInput : UserInput {
        public bool IsActive { set; get; }
    }

}
