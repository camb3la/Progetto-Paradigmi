using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Paradigmi.Application.Abstractions;
using Paradigmi.Application.Options;
using Paradigmi.Application.Services;
using Paradigmi.Models.Context;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Models.Repositories;


namespace Progetto_Paradigmi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Progetto Paradigmi",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            services.AddFluentValidationAutoValidation();

            var jwtAuthenticationOption = new JwtAuthenticationOption();
            configuration.GetSection("JwtAuthentication")
                .Bind(jwtAuthenticationOption);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    string key = jwtAuthenticationOption.Key;
                    var securityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)
                        );
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtAuthenticationOption.Issuer,
                        IssuerSigningKey = securityKey
                    };
                });

            services.AddOptions(configuration);

            return services;
        }

        private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAuthenticationOption>(
                configuration.GetSection("JwtAuthentication")
                );

            return services;
        }


        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<UtenteRepository>();
            services.AddScoped<LibroRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<TokenJWTRepository>();

            return services;
        }


        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies().
                SingleOrDefault(assembly => assembly.GetName().Name == "Paradigmi.Application")
            );

            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ITokenJWTService, TokenJWTService>();

            return services;
        }
    }
}
