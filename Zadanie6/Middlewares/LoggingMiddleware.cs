using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie6.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            if (context.Request != null)
            {
                string path = context.Request.Path;
                string method = context.Request.Method;
                string queryString = context.Request.QueryString.ToString();
                string bodyStr = "";

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true)){
                      bodyStr = await reader.ReadToEndAsync();
                      context.Request.Body.Position = 0;
                }


                List<String> log = new List<String>();
                log.Add("Path:" +path);
                log.Add("Method:" + method);
                log.Add("QueryString:" + queryString);
                log.Add("Body:" +bodyStr);

                await File.AppendAllLinesAsync("Log.txt ", log, Encoding.UTF8);
            }

            await _next(context);
        }
    }
}
