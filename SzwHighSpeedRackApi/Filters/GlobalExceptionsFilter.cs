using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzwHighSpeedRack;
using SzwHighSpeedRack.Aop;

namespace SzwHighSpeedRackApi
{
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var httpContext = filterContext.HttpContext;//"为所欲为"
            bool result = false;

            var xreq = httpContext.Request.Headers.ContainsKey("x-requested-with");
            if (xreq)
            {
                result = httpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            }

            if (!filterContext.ExceptionHandled)
            {
                LogModule.LogError(this.GetLogStr(filterContext.HttpContext, filterContext.Exception));
                HttpResponse response = filterContext.HttpContext.Response;
                response.ContentType = "application/json";
                response.WriteAsync(new
                {
                    Result = 0,
                    DebugMessage = filterContext.Exception.Message,
                    RetValue = "",
                    PromptMsg = "发生错误，请联系管理员"
                }.ToJson());
                filterContext.ExceptionHandled = true;//已经被我处理了
            }
        }

        private string GetLogStr(HttpContext httpContext, Exception ex)
        {
            string getAbsoluteUri = GetAbsoluteUri(httpContext.Request);
            string exception = ex.ToString();
            string referer = httpContext.Request.Headers["Referer"].ToString();
            string cookie = httpContext.Request.Cookies["UserName"];
            string reqMethond = httpContext.Request.Method;
            return new { getAbsoluteUri, referer, cookie, reqMethond, exception }.ToJson();
        }
        private static string GetAbsoluteUri(HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }
    }
}
