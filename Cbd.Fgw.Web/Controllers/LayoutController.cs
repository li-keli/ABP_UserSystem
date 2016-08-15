using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Localization;
using Abp.Threading;
using Cbd.Fgw.Web.Models.Layout;

namespace Cbd.Fgw.Web.Controllers {
    public class LayoutController : FgwControllerBase {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;

        public LayoutController(IUserNavigationManager userNavigationManager, ILocalizationManager localizationManager) {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
        }

        [ChildActionOnly]
        public PartialViewResult TopMenu(string activeMenu = "") {
            var model = new TopMenuViewModel {
                MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.UserId)),
                ActiveMenuItemName = activeMenu
            };

            return PartialView("_TopMenu", model);
        }

        public PartialViewResult LeftMenu() {
            return PartialView("_LeftMenu");
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection() {
            var model = new LanguageSelectionViewModel {
                CurrentLanguage = _localizationManager.CurrentLanguage,
                Languages = _localizationManager.GetAllLanguages()
            };

            return PartialView("_LanguageSelection", model);
        }
    }
}