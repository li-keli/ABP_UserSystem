using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Cbd.Fgw.EntityFramework.EntityFramework.Repositories {
    public abstract class FgwRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FgwDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey> {
        protected FgwRepositoryBase(IDbContextProvider<FgwDbContext> dbContextProvider)
            : base(dbContextProvider) {

        }

    }

    public abstract class FgwRepositoryBase<TEntity> : FgwRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int> {
        protected FgwRepositoryBase(IDbContextProvider<FgwDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }
    }
}
