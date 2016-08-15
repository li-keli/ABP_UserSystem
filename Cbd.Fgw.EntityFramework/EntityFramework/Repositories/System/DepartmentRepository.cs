using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using Cbd.Fgw.Core.IRepository;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.EntityFramework.EntityFramework.Repositories.System {
    public class DepartmentRepository : FgwRepositoryBase<Department>, IDepartmentRepository {
        public DepartmentRepository(IDbContextProvider<FgwDbContext> dbContextProvider) : base(dbContextProvider) {
        }

        public List<Department> GetByParentId(int parentId) {
            var department = GetAll();
            if (department.Count() > 0) {
                department = department.Where(d => d.DepartmentId == parentId);
            }

            return department.ToList();
        }
    }
}
