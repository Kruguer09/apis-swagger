using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiRestConSwagger
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
            //añado el contexto
            services.AddDbContext<Models.HeroContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            //*****************************************
            //INFORMACIÓN básica que tiene nuestra API
            //para los usuarios que la vayan a consumir
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ApiRestConSwagger",
                    Version = "v1",
                    Description = "Ejemplo de API",
                    //TermsOfService = new Uri("https://example.com/terms"),

                    //Datos del autor
                    Contact = new OpenApiContact
                    {
                        Name = "Elisa Fernández",
                        Email = "efernandez@iestrassierra.com",
                        //Url= new Uri(nuestro twitter)
                    },
                    //Datos de la licencia
                    License = new OpenApiLicense
                    {
                        Name = "Use under XXX",
                        Url = new Uri("https://example.com/license"),
                    }
                }); 

                //Obtengo el nombre del archivo xml que va a ser de la forma nombre_proyecto.xml
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //Obtengo el nombre completo del archivo, incluyendo su ruta
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //Incluyo los comentarios XML que estén en el archivo
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiRestConSwagger v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
