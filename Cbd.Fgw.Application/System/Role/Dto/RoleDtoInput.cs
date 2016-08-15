using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.PagedResult;
using System.ComponentModel.DataAnnotations;

namespace Cbd.Fgw.Application.System.Role.Dto {
    [AutoMap(typeof(Core.System.Role))]
    public class RoleDtoInput : IInputDto {
        [Display(Name = "编号")]
        public int Id { set; get; }
    }

    [AutoMap(typeof(Core.System.Role))]
    public class RoleCreateInput : RoleDtoInput {
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于{2}个字符并小于{1}个字符")]
        [Display(Name = "角色名称")]
        public string RoleName { set; get; }

        [Required]
        [Display(Name = "是否系统角色")]
        public bool IsSystem { set; get; }

        [Display(Name = "角色描述")]
        public string Describe { set; get; }
    }

    [AutoMap(typeof(Core.System.Role))]
    public class RoleSearchDtoInput : RoleDtoInput, IDataTableViewModelInput {
        public virtual string RoleName { set; get; }
        public string Order { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    [AutoMap(typeof(Core.System.Role))]
    public class RoleAuthorizationInput : RoleDtoInput {
        public virtual ICollection<Core.System.Menu> Menus { set; get; }
    }
}
