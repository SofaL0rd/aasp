using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<CalcService>();
        builder.Services.AddTransient<ITimeOfDayService, TimeOfDayService>();
        builder.Services.AddControllers();
        var app = builder.Build();

        
        app.Map("/", () =>
        {
            var calcService = app.Services.GetRequiredService<CalcService>();

            return $"Add: {calcService.Add(5, 3)} \n" +
                   $"Subtract: {calcService.Subtract(8, 2)}\n" +
                   $"Multiply: {calcService.Multiply(4, 6)}\n" +
                  $"Divide: {calcService.Divide(9, 3)} \n";
        });

        app.Map("/time", appBuilder =>
        {
            appBuilder.Run(async context =>
            {
                var timeOfDayService = context.RequestServices.GetRequiredService<ITimeOfDayService>();
                var result = timeOfDayService.GetTimeOfDay();
                await context.Response.WriteAsync(result);
            });
        });
        app.Run();
    }

    
}

