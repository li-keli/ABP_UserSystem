using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.PagedResult;

namespace Cbd.Fgw.Application.System.Department.Dto {
    [AutoMap(typeof(Core.System.Department))]
    public class DepartmentInput : DepartmentDto, IInputDto {
    }

    public class DepartmentSearchInput : IDataTableViewModelInput {
        [Display(Name = "部门名称")]
        public string DepartmentName { set; get; }

        public string Order { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    [AutoMap(typeof(Core.System.Department))]
    public class DepartmentCreateInput : IInputDto {
        public int Id { set; get; }
        [Required]
        [Display(Name = "部门名称")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "{0}的长度必须大于{2}个字符并小于{1}个字符")]
        public string DepartmentName { set; get; }
        [Display(Name = "部门描述")]
        public string Describe { set; get; }
        [Display(Name = "上级部门ID")]
        public int DepartmentId { set; get; }
    }
}
