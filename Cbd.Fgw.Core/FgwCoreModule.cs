using System.Reflection;
using Abp.Modules;

namespace Cbd.Fgw.Core
{
    public class FgwCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
