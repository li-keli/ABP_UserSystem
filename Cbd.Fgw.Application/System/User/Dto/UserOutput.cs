using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Cbd.Fgw.Application.PagedResult;

namespace Cbd.Fgw.Application.System.User.Dto {
    public class UserOutput : IOutputDto {
        public List<UserDto> Users { set; get; }
    }

    public class UserSearchOutput : IDataTableViewModelOutput<UserDto> {
        public int Total { get; set; }
        public List<UserDto> Rows { get; set; }
    }

    [AutoMap(typeof(Core.System.User))]
    public class UserAuthorizationOutput : IOutputDto {
        [Display(Name = "角色")]
        public virtual ICollection<Core.System.Role> Roles { set; get; }
    }
}
