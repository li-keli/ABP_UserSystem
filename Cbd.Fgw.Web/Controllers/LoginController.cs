using System.Web.Mvc;
using Abp.Runtime.Session;

namespace Cbd.Fgw.Web.Controllers {
    public class LoginController : FgwControllerBase {

        public ActionResult Index() {
            //AbpSession = NullAbpSession.Instance;
            return View();
        }
    }
}