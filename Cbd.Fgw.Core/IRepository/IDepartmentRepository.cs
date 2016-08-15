using System.Collections.Generic;
using Cbd.Fgw.Core.System;
using Abp.Domain.Repositories;

namespace Cbd.Fgw.Core.IRepository {
    public interface IDepartmentRepository : IRepository<Department> {
        /// <summary>
        /// 通过父Id获取数据
        /// </summary>
        /// <param name="parentId">父Id</param>
        /// <returns></returns>
        List<Department> GetByParentId(int parentId);
    }
}
