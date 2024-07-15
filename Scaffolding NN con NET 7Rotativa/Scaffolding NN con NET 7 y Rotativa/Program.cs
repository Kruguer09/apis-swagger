using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Context;
using Microsoft.EntityFrameworkCore;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Adición del contexto
            builder.Services.AddDbContext<MyDbContext>(opciones =>
                opciones.UseSqlServer("name=DefaultConnection"));

            var app = builder.Build();
            
            //Llamo al método que va a inicializar la base de datos 
            CreateDbIfNotExists(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Configuramos Rotativa indicándole el Path RELATIVO donde se
            //encuentran los archivos de la herramienta wkhtmltopdf
            string wwwroot = app.Environment.WebRootPath;
           
            Rotativa.AspNetCore.RotativaConfiguration
            .Setup(wwwroot, "..\\Rotativa");

            app.Run();
        }
      
        //Método añadido a la plantilla para inicializar la base de datos
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
    }
}