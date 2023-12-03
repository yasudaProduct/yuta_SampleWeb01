using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog.Web;
using System.Security.Claims;

namespace Merino.Filters
{
    public class AccessLogFilter : IActionFilter
    {
        /// <summary>
        /// アクションメソッド実行前の処理
        /// </summary>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            OutputAccessLog(filterContext, "Start");
        }

        /// <summary>
        /// アクションメソッド実行後の処理
        /// </summary>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            OutputAccessLog(filterContext, "End");
        }

        /// <summary>
        /// アクセスログを出力する
        /// </summary>
        private void OutputAccessLog(FilterContext filterContext, string starOrtEnd)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
                var name = filterContext.HttpContext.User.FindFirst(ClaimTypes.Name).Value;

                logger.Info($"Controller:{controllerActionDescriptor.ControllerName} Action:{controllerActionDescriptor.ActionName} User:{(name ?? "Not User")} {starOrtEnd}");
            }
            catch (Exception ex)
            {
                logger.Error("\r\n" + "ログ出力時にエラーが発生しました。" + ex);
            }
        }
    }
}
