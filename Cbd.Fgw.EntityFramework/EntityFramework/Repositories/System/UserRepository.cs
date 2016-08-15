using System.Linq;
using System.Data.Entity;
using Abp.EntityFramework;
using Cbd.Fgw.Core.System;
using Cbd.Fgw.Core.IRepository;
using System.Collections.Generic;

namespace Cbd.Fgw.EntityFramework.EntityFramework.Repositories.System {
    public class UserRepository : FgwRepositoryBase<User>, IUserRepository {
        public UserRepository(IDbContextProvider<FgwDbContext> dbContextProvider) : base(dbContextProvider) {
        }

        public List<User> GetUsers(User input) {
            var query = GetAll()
                .Include(t => t.Roles)
                .Include(t => t.Department);
            if (input.Id != default(int)) {
                query = query.Where(user => user.Id == input.Id);
            }

            return query.ToList();
        }

        public IQueryable<User> GetUserAndRoles() {
            return GetAll().Include(t => t.Roles);
        }
    }
}
