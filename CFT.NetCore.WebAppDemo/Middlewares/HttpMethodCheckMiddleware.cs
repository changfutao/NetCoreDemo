using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Middlewares
{
    public class HttpMethodCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpMethodCheckMiddleware> _logger;

        public HttpMethodCheckMiddleware(
            RequestDelegate requestDelegate,
            IWebHostEnvironment webHostEnvironment,
            ILogger<HttpMethodCheckMiddleware> logger
            )
        {
            _next = requestDelegate;
            this._logger = logger;
        }

        public Task Invoke(HttpContext context)
        {
            //输出每一次请求的URL地址
            _logger.LogInformation($"请求地址: {context.Request.Path}");
            //获取每一次请求的HTTPMethod
            _logger.LogInformation($"请求方法{context.Request.Method}")

            return _next(context);
        }
    }
}
