
namespace WeatherWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = ConfigureServices(args);
            var app = builder.Build();
            BuildMiddlewarePipeline(app);
        }

        private static void BuildMiddlewarePipeline(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();
        }

        private static WebApplicationBuilder ConfigureServices(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }
    }
}
