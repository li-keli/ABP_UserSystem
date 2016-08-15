using System.Web.Mvc;
using Abp.Authorization;

namespace Cbd.Fgw.Web.Controllers {
    public class HomeController : FgwControllerBase {

        [AbpAuthorize]
        public ActionResult Index() {
            return View();
        }

        public ActionResult ControlBoard() {
            return View();
        }
    }
}