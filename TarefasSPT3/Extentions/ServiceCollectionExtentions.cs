
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.Design;
using TarefasSPT3.Configuration;
using TarefasSPT3.Data;

namespace TarefasSPT3.Extentions
{

    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDBContexts(this IServiceCollection service, AppConfiguration appConfiguration)
        {
            service.AddDbContext<SistemasTarefasDBContext>(options =>
            {
                options.UseOracle(appConfiguration.ConnectionStrings.OracleFIAP);
            });

            return service;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection service, AppConfiguration appConfiguration)
        {

            service.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact()
                    {
                        Email = appConfiguration.Swagger.Email,
                        Name = appConfiguration.Swagger.Name
                    }
                }
                );
            });


            return service;
        }
    }
}
