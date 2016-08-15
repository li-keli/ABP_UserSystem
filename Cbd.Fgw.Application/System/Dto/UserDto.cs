using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Cbd.Fgw.System.Dto {

    [AutoMap(typeof(User))]
    public class UserDto : EntityDto {
        [Display(Name = "用户名")]
        public virtual string UserName { set; get; }
    }

}
