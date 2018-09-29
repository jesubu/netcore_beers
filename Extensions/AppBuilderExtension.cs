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
        //public static void UserTime(this IApplicationBuilder app,TimerMiddlewareOptions options=null)
        //{
        //    app.UseMiddleware<TimerMiddleware>(options ?? new TimerMiddlewareOptions());

        //}

            //una Accion es una funcion, un delegado a una funcion
        public static void UserTime(this IApplicationBuilder app, 
            Action<TimerMiddlewareOptions> optionsAction = null)
        {
            var options = new TimerMiddlewareOptions();
            //////hacemos lo que queramos con el objeto
            ////optionsAction.Invoke(options);
            //////como options puede ser null podemos hacer:
            //if (optionsAction != null)
            //{
            //    optionsAction.Invoke(options);
            //}
            ////para evitar esto hacemos lo siguiente:
            optionsAction?.Invoke(options);

            app.UseMiddleware<TimerMiddleware>(options);

        }
        public static void UseMethodOverride(this IApplicationBuilder app)
        {
            app.UseMiddleware<XMethodOverrideMiddleware>();
        }
    }
}
