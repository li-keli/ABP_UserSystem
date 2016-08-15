using Abp.Web.Mvc.Views;
using Cbd.Fgw.Core;

namespace Cbd.Fgw.Web.Views {
    public abstract class FgwWebViewPageBase : FgwWebViewPageBase<dynamic> {

    }

    public abstract class FgwWebViewPageBase<TModel> : AbpWebViewPage<TModel> {
        protected FgwWebViewPageBase() {
            LocalizationSourceName = FgwConsts.LocalizationSourceName;
        }
    }
}