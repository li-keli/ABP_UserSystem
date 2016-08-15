using System.Web.Mvc;

namespace Cbd.Common.HtmlHelper {
    public static class IcoHelper {
        public static MvcHtmlString Iischeck(this System.Web.Mvc.HtmlHelper htmlHelper, bool isTrue = false) {
            var isClose = isTrue ? "check" : "close";

            return MvcHtmlString.Create($"<i class='fa fa-{isClose}'></i>");
        }
    }
}
