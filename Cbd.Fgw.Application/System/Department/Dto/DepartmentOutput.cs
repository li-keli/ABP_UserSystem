using System.Collections.Generic;
using Abp.AutoMapper;
using Cbd.Fgw.Application.PagedResult;

namespace Cbd.Fgw.Application.System.Department.Dto {
    [AutoMap(typeof(Core.System.Department))]
    public class DepartmentOutput : DepartmentDto {
    }

    [AutoMap(typeof(Core.System.Department))]
    public class DepartmentSearchOutput : IDataTableViewModelOutput<DepartmentBaseDto> {
        public int Total { get; set; }
        public List<DepartmentBaseDto> Rows { get; set; }
    }

}
