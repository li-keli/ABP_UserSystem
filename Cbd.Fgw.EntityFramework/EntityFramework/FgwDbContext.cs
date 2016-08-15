using System.Data.Entity;
using Abp.EntityFramework;
using Cbd.Fgw.Core.System;

namespace Cbd.Fgw.EntityFramework.EntityFramework {
    public class FgwDbContext : AbpDbContext {
        public FgwDbContext()
            : base("Default") {

        }
        public FgwDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) {

        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Role> Roles { get; set; }
        public virtual IDbSet<Menu> Menus { get; set; }
        public virtual IDbSet<Department> Departments { get; set; }

    }
}
