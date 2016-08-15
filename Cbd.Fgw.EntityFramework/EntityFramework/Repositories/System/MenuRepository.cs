using Abp.EntityFramework;
using Cbd.Fgw.Core.IRepository;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.EntityFramework.EntityFramework.Repositories.System
{
    public class MenuRepository : FgwRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbContextProvider<FgwDbContext> dbContextProvider) : base(dbContextProvider){
        }
    }
}
