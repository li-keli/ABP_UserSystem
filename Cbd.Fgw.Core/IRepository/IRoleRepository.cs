using Abp.Domain.Repositories;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.Core.IRepository {
    public interface IRoleRepository : IRepository<Role> {
        /// <summary>
        /// 获取Role包含Menu
        /// </summary>
        Role GetAndMenu(int id);
    }
}
