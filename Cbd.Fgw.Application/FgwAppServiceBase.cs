using Abp.Application.Services;
using Cbd.Fgw.Core;

namespace Cbd.Fgw.Application {
    public abstract class FgwAppServiceBase : ApplicationService {
        protected FgwAppServiceBase() {
            LocalizationSourceName = FgwConsts.LocalizationSourceName;
        }


    }
}