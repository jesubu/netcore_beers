using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using apibeers.Data;
using apibeers.Extensions;
using apibeers.Middleware;


namespace apibeers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //cuando utilizamos un proveedor externo, por ejem. Autofac, para la inyeccion de dependencias
            //la clase ConfigureServices, no retorna void, sino un objeto tipo IServiceProvider

            //0:41


            ////services.AddTransient<BeersRespository>();
            ////AddTransient-->el controlador se crea una vez por cada petición

            ////services.AddSingleton<BeersRespository>();
            ////se crea solo una instancia del controlador, la primera vez que sea solicitada
            //services.AddSingleton<IBeersRespository, BeersRespository>(); // -->El sistema de inyeccion de dependencia es quien
            ////crea el objeto y hace el dispose. el asume 
            ////services.AddSingleton<IBeersRespository> ( new BeersRespository()); // -->yo indico al inyector el objeto y soy quien lo crea
            ////ocurre que aki no hace el dispose.

            ////services.AddScoped<BeersRespository>();
            ////es singleton solo en el contexto, solo en el contexto de la petición

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();

            builder.RegisterType<BeersRespository>().As<IBeersRespository>().SingleInstance();
            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ////app.UseMiddleware<TimerMiddleware>();
            ////app.UserTime();
            //app.UserTime(new TimerMiddlewareOptions()
            //{
            //    Text = "Time elapse"
            //});

            app.UserTime(options =>
            {
                options.SetDefaultMessage();
            });


            ////si quisieramos aplicar un middleware especifico a
            ////todas las peticiones de un pipeline que sean por ejem: admin
            ////deberiamos de poner lo siguiente:
            //app.Map("/admin", x =>
            //{
            //    x.UseMiddleware<TimerMiddleware>();
            //});
            //podemos tener distintos pipeline enfuncion dela url o cabecera.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //app.UseMiddleware<XMethodOverrideMiddleware>();
            app.UseMethodOverride();

            app.UseHttpsRedirection();
            app.UseMvc(x=>x.MapRoute("default","{controller}/{action}"));
        }
    }
}
