using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using Cbd.Fgw.Application;
using Cbd.Fgw.Core;
using Cbd.Fgw.EntityFramework;
using Cbd.Fgw.WebApi;

namespace Cbd.Fgw.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(FgwDataModule), 
        typeof(FgwApplicationModule), 
        typeof(FgwWebApiModule))]
    public class FgwWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    FgwConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/Fgw")
                        )
                    )
                );

            //Configuration.Navigation.Providers.Add<FgwNavigationProvider>();
            Configuration.Authorization.Providers.Add<FgwAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
