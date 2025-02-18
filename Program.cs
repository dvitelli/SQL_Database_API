using Utility.CreateDatabase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
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
            
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        
            
            var app = builder.Build();
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            

        }
    }
}

