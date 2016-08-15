using System.Data.Entity;
using System.Linq;
using Abp.EntityFramework;
using Cbd.Fgw.Core.IRepository;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.EntityFramework.EntityFramework.Repositories.System {
    public class RoleRepository : FgwRepositoryBase<Role>, IRoleRepository {
        public RoleRepository(IDbContextProvider<FgwDbContext> dbContextProvider) : base(dbContextProvider) {
        }

        public Role GetAndMenu(int id) {
            return GetAll().Include(r => r.Menus).SingleOrDefault(r => r.Id == id);
        }
    }
}
