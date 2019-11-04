using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace AtivaInvestimentos.API.Configuration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Fundos de Investimentos",
                        Version = "v1",
                        Description = "Projeto em .NET Core, Docker e Entity Framework que permite ao cliente listar fundos de investimentos, aplicar e resgatar.",
                        Contact = new Contact
                        {
                            Name = "Vinicius Roberto"
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
