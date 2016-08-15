using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Cbd.Common.HtmlHelper {
    public static class CheckboxHelper {
        /// <summary>
        /// 美化的Checkbox
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString BeautifulCheckbox<TEntity, TProperty>(this HtmlHelper<TEntity> htmlHelper, Expression<Func<TEntity, TProperty>> expression, string id = null) {
            var idString = "";
            if (id != null) {
                idString = $"id=\"{id}\" ";
            }
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            StringBuilder checkbox = new StringBuilder();
            checkbox.Append(" <div class=\"checkbox\"> ");
            checkbox.Append(" <label> ");
            checkbox.Append($" <input type=\"checkbox\" value=\"${modelMetadata.Model}\" ${idString} ");
            checkbox.Append(" </label> ");
            checkbox.Append(" </div> ");

            return MvcHtmlString.Create(checkbox.ToString());
        }
    }
}
