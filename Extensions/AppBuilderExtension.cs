using apibeers.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Extensions
{
    public static class IAppBuilderExtension
    {
        public static void UserTime(this IApplicationBuilder app,TimerMiddlewareOptions options=null)
        {
            app.UseMiddleware<TimerMiddleware>(options ?? new TimerMiddlewareOptions());

        }
        public static void UseMethodOverride(this IApplicationBuilder app)
        {
            app.UseMiddleware<XMethodOverrideMiddleware>();
        }
    }
}
