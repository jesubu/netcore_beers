using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibeers.Middleware
{
    public class XMethodOverrideMiddleware
    {
        private readonly RequestDelegate _next;
        public XMethodOverrideMiddleware(RequestDelegate next) => _next = next;


        public async Task Invoke(HttpContext ctx)
        {
            //metodo asincrono
            //Analizar la petición y modificar la petición si cabe
            var request = ctx.Request;
            if (request.Headers.ContainsKey("X-HTTP-Method-Override"))
            {
                var header = request.Headers["X-HTTP-Method-Override"];
                request.Method = header;
             }

            //Generamos una resupuesta si queremos
            await _next.Invoke(ctx);
            //Analizamos la respuesta y modidicamos si cabe
            //y cedemos el control al siguiente control

            int i = 0;

        }
        
    }
}
