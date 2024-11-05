// Program.cs
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TarefasSPT3.Configuration;
using TarefasSPT3.Extensions;
using TarefasSPT3.Repositories;
using TarefasSPT3.Repositories.Interfaces;

public partial class Program // Make Program public and partial
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Bind das configurações
        builder.Services.Configure<AppConfiguration>(builder.Configuration);

        // Recupera a instância de AppConfiguration
        var appConfig = builder.Configuration.Get<AppConfiguration>();

        // Serviços
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDocumentation(appConfig);
        builder.Services.AddDBContexts(appConfig);

        // Repositórios
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

        // Serviços de IA
        builder.Services.AddRecommendationService();

        // Autenticação
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{appConfig.Auth0.Domain}/";
                options.Audience = appConfig.Auth0.Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://{appConfig.Auth0.Domain}/",
                    ValidateAudience = true,
                    ValidAudience = appConfig.Auth0.Audience,
                    ValidateLifetime = true
                };
            });

        var app = builder.Build();

        // Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication(); // Deve ser chamado antes de UseAuthorization
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
