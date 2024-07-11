using KarateChopDomain;

namespace KarateChopApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer(); // Add the endpoint API explorer service
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "KarateChopApi", Version = "v1" });
                c.EnableAnnotations();
            }); // Add the Swagger generator service

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/", () => "Welcome to KarateChop API!");

            // Create an endpoint to perform binary search operations
            app.MapGet("/chop", (int target, int[] array) =>
            {
                int result = KarateChop.Chop(target, array);

                if (result != -1)
                    return Results.Ok(new { Message = $"Target {target} found at index {result}", Index = result });
                else
                    return Results.NotFound(new { Message = $"Target {target} not found in the array" });
            });

            app.Run();
        }
    }
}
