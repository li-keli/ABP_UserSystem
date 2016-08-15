using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Cbd.Fgw.System.Dto {
    public class UserInput : IInputDto {
        public int? Id { set; get; }

        [StringLength(40, MinimumLength = 1)]
        public string SearchedName { set; get; }
    }

    [AutoMap(typeof(User))]
    public class UserCreateInput : IInputDto {
        [Required]
        [Display(Name = "用户名")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于{2}个字符并小于{1}个字符")]
        public string UserName { set; get; }
        [Required]
        [Display(Name = "密码")]
        public string Pwd { set; get; }
    }

    [AutoMap(typeof(User))]
    public class UserSearchInput : IInputDto {

        [StringLength(40, MinimumLength = 1)]
        public virtual string UserName { set; get; }
    }

    public class UserUpdateInput : IInputDto {
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string Pwd { set; get; }
    }
}
