using Cbd.Fgw.Core;
using System.Web.Mvc;
using Abp.Web.Mvc.Controllers;
using Abp.Web.Mvc.Controllers.Results;
using Newtonsoft.Json;

namespace Cbd.Fgw.Web.Controllers {
    public abstract class FgwControllerBase : AbpController {
        protected FgwControllerBase() {
            LocalizationSourceName = FgwConsts.LocalizationSourceName;
        }

        public new ActionResult Json(object obj) {
            return new AbpJsonResult(obj) { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult JsonByString(object obj) {
            var json = JsonConvert.SerializeObject(obj, Formatting.None,
                 new JsonSerializerSettings {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                 });
            return Content(json, "application/json; charset=utf-8");
        }
    }
}