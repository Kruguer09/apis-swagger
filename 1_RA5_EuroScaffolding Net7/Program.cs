using EuroScaffolding2.Context;
using EuroScaffolding2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace EuroScaffolding2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Modificaciones introducidas en este ejemplo
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);

            host.Run();
        }
        //Método añadido a la plantilla
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MyDbContext>();

                    //Llamo al método Initialize pasándole el contexto
                    //para que se cree la base de datos y se inialice con datos
                    //de prueba
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
