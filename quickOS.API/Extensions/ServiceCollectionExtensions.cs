﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using quickOS.Application.Interfaces;
using quickOS.Infra.Auth;
using quickOS.Infra.Persistence;

namespace quickOS.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "quickOS.API", Version = "1.0" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT authorization header"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        });

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<QuickOSDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("quickOS")));

        // services.AddScoped<IUnitOfWork, UnitOfWork>();

        // services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
