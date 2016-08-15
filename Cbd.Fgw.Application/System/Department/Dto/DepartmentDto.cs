using Abp.AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cbd.Fgw.Application.System.User.Dto;

namespace Cbd.Fgw.Application.System.Department.Dto {
    [JsonObject(MemberSerialization.OptOut)]
    [AutoMap(typeof(Core.System.Department))]
    public class DepartmentDto : DepartmentBaseDto {
        [Display(Name = "用户")]
        public virtual ICollection<UserDto> Users { set; get; }
    }

    [AutoMap(typeof(Core.System.Department))]
    public class DepartmentBaseDto : EntityDto {
        [Required]
        [Display(Name = "部门名称")]
        public string DepartmentName { set; get; }
        [Display(Name = "部门描述")]
        public string Describe { set; get; }
        [Display(Name = "上级部门ID")]
        public virtual int DepartmentId { set; get; }
        [Display(Name = "是否系统部门")]
        public bool IsSystem { set; get; }
        [Display(Name = "上级部门")]
        [ForeignKey("DepartmentId")]
        public virtual DepartmentBaseDto ParentDepartment { set; get; }
    }
}
