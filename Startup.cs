using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apibeers.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        public void ConfigureServices(IServiceCollection services)
        {
            //0:41


            //services.AddTransient<BeersRespository>();
            //AddTransient-->el controlador se crea una vez por cada petición

            //services.AddSingleton<BeersRespository>();
            //se crea solo una instancia del controlador, la primera vez que sea solicitada
            services.AddSingleton<IBeersRespository, BeersRespository>(); // -->El sistema de inyeccion de dependencia es quien
            //crea el objeto y hace el dispose. el asume 
            //services.AddSingleton<IBeersRespository> ( new BeersRespository()); // -->yo indico al inyector el objeto y soy quien lo crea
            //ocurre que aki no hace el dispose.

            //services.AddScoped<BeersRespository>();
            //es singleton solo en el contexto, solo en el contexto de la petición

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(x=>x.MapRoute("default","{controller}/{action}"));
        }
    }
}
