using System.Reflection;
using Abp.Modules;
using Cbd.Fgw.Core;

namespace Cbd.Fgw.Application {
    [DependsOn(typeof(FgwCoreModule))]
    public class FgwApplicationModule : AbpModule {
        public override void Initialize() {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
