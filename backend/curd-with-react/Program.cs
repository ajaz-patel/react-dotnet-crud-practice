
using curd_with_react.Data;

namespace curd_with_react
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<DapperContext>();
            /*builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactAppPolicy", builder =>
                {
                    builder.AllowAnyOrigin()   // Replace with your React app's URL
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
                builder.Services.AddControllers();
            });*/ 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(options =>
                {
                    options.AllowAnyOrigin();   
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                }
                );
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
