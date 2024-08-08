using Microsoft.EntityFrameworkCore;

using TestProject.Context;

using WebApplication1.Extentions;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddServices();
            builder.AddAuth();
            builder.Services.AddMappingProfiles();

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            builder.Services.AddDbContext<ApplicationContext>(options =>
                   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
