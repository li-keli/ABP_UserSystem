using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.UI;
using AutoMapper;
using Cbd.Fgw.Core.IRepository;
using Cbd.Fgw.Application.System.Department.Dto;

namespace Cbd.Fgw.Application.System.Department {

    public class DepartmentService : FgwAppServiceBase, IDepartmentService {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository) {
            _departmentRepository = departmentRepository;
        }

        public DepartmentDto Get(int id) {
            var department = _departmentRepository.Get(id);
            Mapper.CreateMap<Core.System.Department, DepartmentDto>();

            return department.MapTo<DepartmentDto>();
        }

        public List<DepartmentDto> GetAll() {
            var departmentList = _departmentRepository.GetAll();
            Mapper.CreateMap<Core.System.Department, DepartmentDto>();

            return departmentList.MapTo<List<DepartmentDto>>();
        }

        public DepartmentSearchOutput GetAll(DepartmentSearchInput input) {
            if (input == null) {
                input = new DepartmentSearchInput();
            }

            Logger.Info(" 查询部门信息，查询内容： " + input);
            var departmentAll = _departmentRepository.GetAllList();
            var total = departmentAll.Count;
            departmentAll.WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentName), r => r.DepartmentName.Contains(input.DepartmentName));
            if (departmentAll == null) {
                throw new UserFriendlyException("未查询到数据。");
            }
            Mapper.CreateMap<Core.System.Department, DepartmentBaseDto>();
            var rows = departmentAll.MapTo<List<DepartmentBaseDto>>();
            rows = rows.Skip(input.Offset).Take(input.Limit).ToList();

            return new DepartmentSearchOutput { Total = total, Rows = rows };
        }

        public List<DepartmentTreeAsync> GetTreeAsync(int? id) {
            var department = id.HasValue ? _departmentRepository.GetByParentId(id.Value) : _departmentRepository.GetAllList(d => d.Id == 1);
            var departmentTreeAsyncs = new List<DepartmentTreeAsync>();
            department.ForEach(d => departmentTreeAsyncs.Add(new DepartmentTreeAsync {
                id = d.Id,
                isParent = true,
                name = d.DepartmentName
            }));

            return departmentTreeAsyncs;
        }

        public void Create(DepartmentCreateInput input) {
            var department = input.MapTo<Core.System.Department>();
            _departmentRepository.Insert(department);
        }

        public void Edit(DepartmentCreateInput input) {
            var department = input.MapTo<Core.System.Department>();
            _departmentRepository.Update(department);
        }

        public void Delete(int id) {
            var department = _departmentRepository.GetAll().Where(d => d.Id == id);
            if (department.Count() > 1) {
                throw new UserFriendlyException("未找到该部门！");
            }

            _departmentRepository.Delete(id);
        }
    }
}
