using ARScaffoldingJoseAFerreRico.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //*****************************************   
        //INFORMACIÓN básica que tiene nuestra API   
        //para los usuarios que la vayan a consumir
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ApiConSwagger de Empresas de Jose Antonio Ferre Rico",
                Version = "version1",
                Description = "API de EMPRESAS",
                //TermsOfService = new Uri("https://example.com/terms"),          
                //Datos del autor
                Contact = new OpenApiContact
                {
                    Name = "Jose Antonio Ferre Rico",
                    Email = "jferric213@g.educaand.es",
                    Url= new Uri("Https://www.")
                },
                //Datos de la licencia
                License = new OpenApiLicense
                {
                    Name = "Use under JoseleCom",
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
        
        builder.Services.AddSwaggerGen();

        //Adición del contexto
        builder.Services.AddDbContext<EmpresaContext>(opciones =>
         opciones.UseSqlServer("name=DefaultConnection"));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}