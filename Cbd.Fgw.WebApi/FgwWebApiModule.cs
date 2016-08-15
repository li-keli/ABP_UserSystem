using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Cbd.Fgw.Application;

namespace Cbd.Fgw.WebApi {
    [DependsOn(typeof(AbpWebApiModule), typeof(FgwApplicationModule))]
    public class FgwWebApiModule : AbpModule {
        public override void Initialize() {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(FgwApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
