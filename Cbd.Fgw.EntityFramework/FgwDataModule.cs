using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Cbd.Fgw.Core;
using Cbd.Fgw.EntityFramework.EntityFramework;

namespace Cbd.Fgw.EntityFramework {
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(FgwCoreModule))]
    public class FgwDataModule : AbpModule {
        public override void PreInitialize() {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize() {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<FgwDbContext>(null);
        }
    }
}
