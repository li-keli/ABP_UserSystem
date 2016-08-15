using Abp.Application.Navigation;
using Abp.Localization;
using Cbd.Fgw.Core;

namespace Cbd.Fgw.Web {
    public class FgwNavigationProvider : NavigationProvider {
        public override void SetNavigation(INavigationProviderContext context) {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Pro",
                        new LocalizableString("Home", FgwConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-home"
                        )
                );
        }
    }
}
