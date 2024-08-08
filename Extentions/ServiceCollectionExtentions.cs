using AutoMapper;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using System.Reflection;
using System.Text;

using TestProject.Configuration;
using TestProject.Interfaces;
using TestProject.Mapping.Profiles;
using TestProject.Models;
using TestProject.Repositories;
using TestProject.Services;

using WebApplication1.Configuration;
using WebApplication1.Interfaces;
using WebApplication1.Services;
namespace WebApplication1.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IS3Options, S3Options>();
            builder.Services.AddScoped<IS3Service, S3Service>();
            builder.Services.AddScoped<IJwtOptions, JwtOptions>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.Configure<S3Options>(builder.Configuration.GetSection("AWS"));
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }

        public static void AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true, // Correctly set to true
                    ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
                    ValidAudience = builder.Configuration["JwtOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"])) // Correctly set the signing key
                };
            });
        }

        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddScoped<AuthProfile>();

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var profiles = scope.ServiceProvider.GetWithBase<Profile>(typeof(AuthProfile).Assembly);
                cfg.AddProfiles(profiles);
                scope.Dispose();
            }).CreateMapper());

            return services;
        }
        public static IEnumerable<T> GetWithBase<T>(this IServiceProvider serviceProvider, Assembly assembly)
        {
            var baseType = typeof(T);
            var types = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && t.BaseType == baseType);

            foreach (var type in types)
            {
                yield return (T)serviceProvider.GetService(type);
            }
        }
    }
}
