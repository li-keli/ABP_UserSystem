using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.Core.IRepository {
    public interface IUserRepository : IRepository<User> {
        List<User> GetUsers(User input);

        /// <summary>
        /// 获取User包含Role内容
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetUserAndRoles();
    }
}
