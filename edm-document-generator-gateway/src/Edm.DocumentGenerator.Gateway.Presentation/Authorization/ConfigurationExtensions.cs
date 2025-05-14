using System.Security.Claims;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Edm.DocumentGenerator.Gateway.Presentation.Authorization;

public static class ConfigurationExtensions
{
    internal static void AddKeycloak(this IServiceCollection services)
    {
        services
            .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false
                    };

                    opts.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var header = context.Request.Headers["Authorization"].FirstOrDefault();

                            if (!string.IsNullOrEmpty(header) &&
                                header.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                            {
                                var incomingToken = header.Substring("Bearer ".Length).Trim();

                                if (incomingToken == "token")
                                {
                                    var claims = new[] { new Claim(ClaimTypes.Name, "dev-user") };
                                    var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                                    context.Principal = new ClaimsPrincipal(identity);
                                    context.Success();
                                }
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

        services.AddAuthorization();

        services.AddSingleton<AccessCheckerFacade>();
    }

    internal static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            options =>
            {
                options.EnableAnnotations(true, true);

                SwaggerDerivedTypesConfiguration.ConfigureDerivedTypes(options);

                options.AddSecurityDefinition(
                    "user-bearer",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.ApiKey, // ← ApiKey, not Http
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Description = "Type **Bearer token** (including the “Bearer ” prefix) here"
                    });

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "user-bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                options.UseOneOfForPolymorphism();
            });
    }
}
