using ControlEscolarApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            Console.WriteLine(builder.Configuration.GetConnectionString("CatalogoEscolarDbContext"));

            //Agrehando conectividad a BD
            builder.Services.AddDbContext<CatalogoEscolarDbContext>( options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogoEscolarDbContext"))
                
                ); 

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}