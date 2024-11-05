// Extensions/ServiceCollectionExtensions.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TarefasSPT3.Configuration;
using TarefasSPT3.Data;
using TarefasSPT3.ML.Services;
using TarefasSPT3.Services;

namespace TarefasSPT3.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDBContexts(this IServiceCollection services, AppConfiguration appConfig)
        {
            services.AddDbContext<SistemasTarefasDBContext>(options =>
                options.UseOracle(appConfig.ConnectionStrings.OracleFIAP));

            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, AppConfiguration appConfig)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = "JWT Authorization header usando o esquema Bearer."
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        Array.Empty<string>()
                    }
                });
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfig.Swagger.Title,
                    Version = "v1",
                    Description = appConfig.Swagger.Description,
                    Contact = new OpenApiContact
                    {
                        Email = appConfig.Swagger.Email,
                        Name = appConfig.Swagger.Name
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddRecommendationService(this IServiceCollection services)
        {
            services.AddScoped<IRecommendationService, RecommendationService>();
            return services;
        }
    }
}
