using System.Collections.Generic;
using Cbd.Fgw.Application.System.Department.Dto;

namespace Cbd.Fgw.Application.System.Department {
    public interface IDepartmentService {
        DepartmentDto Get(int id);
        DepartmentSearchOutput GetAll(DepartmentSearchInput input);
        List<DepartmentDto> GetAll();
        List<DepartmentTreeAsync> GetTreeAsync(int? id);
        void Create(DepartmentCreateInput input);
        void Edit(DepartmentCreateInput input);
        void Delete(int id);
    }
}