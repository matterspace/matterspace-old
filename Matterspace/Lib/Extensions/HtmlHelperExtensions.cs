using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Matterspace.Lib.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ReactMdeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            if (htmlHelper == null) throw new ArgumentNullException(nameof(htmlHelper));
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var name = ExpressionHelper.GetExpressionText(expression);
            var fullHtmlFieldName = htmlHelper
                .ViewContext
                .ViewData
                .TemplateInfo
                .GetFullHtmlFieldName(name);

            var value = ModelMetadata.FromLambdaExpression(
               expression, htmlHelper.ViewData
           ).Model;

            var reactMdeContainerId = "container_" + fullHtmlFieldName;

            var div = $"<div id=\"{reactMdeContainerId}\"></div>";
            var script = $"<script>document.addEventListener(\"DOMContentLoaded\", function() {{ window._renderMarkdownEditor(\"{"#" + reactMdeContainerId}\", \"{fullHtmlFieldName}\", \"{fullHtmlFieldName}\", \"{value}\"); }});</script>";

            return MvcHtmlString.Create($"{div}\n{script}");
        }
    }
}