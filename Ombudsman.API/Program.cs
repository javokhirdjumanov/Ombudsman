using DataLayer;
using Ombudsman.API.Middliwares;
using ServiceLayer;

namespace Ombudsman.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddDataLayer(builder.Configuration)
                .AddServiceLayer()
                .AddApis(builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandling>();

            app.MapControllers();

            app.Run();
        }
    }
}