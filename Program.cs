using Utility.CreateDatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Backend.Repositories;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CreateDatabase database = new CreateDatabase();
            database.DatabaseCreation();
            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
                     
            var app = builder.Build();
            app.UseDeveloperExceptionPage();
            
            #if DEBUG
                app.MapOpenApi("/openapi/v1.json");
                app.UseSwaggerUI(options =>
                  {
                      options.SwaggerEndpoint("/openapi/v1.json", "Swagger Demo");
                  });
            #endif  
             
            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}

