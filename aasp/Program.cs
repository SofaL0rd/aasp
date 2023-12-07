using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("library_config.json", optional: false, reloadOnChange: true);
        var app = builder.Build();

        app.Map("/Library", LibraryHandler);
        app.Map("/Library/Books", BooksHandler);
        app.Map("/Library/Profile/{id?}", ProfileHandler);

        app.Run();
    }
    private static void LibraryHandler(HttpContext context)
    {
        context.Response.WriteAsync("Greetings from the library!");
    }

    private static void BooksHandler(HttpContext context)
    {
        var booksConfig = context.RequestServices.GetRequiredService<IConfiguration>().GetSection("Books");

        Console.WriteLine(booksConfig);
        context.Response.WriteAsync("List of books:\n");
        foreach (var book in booksConfig.GetChildren())
        {
            var name = book["Name"];
            var author = book["Author"];
            var yearPublished = book["Year published"];

            context.Response.WriteAsync($"Name: {name}, Author: {author}, Year Published: {yearPublished}\n");
        }
    }

    private static void ProfileHandler(HttpContext context)
    {
        if (context.Request.RouteValues.TryGetValue("id", out var idObj) && int.TryParse(idObj?.ToString(), out var userId) && userId >= 0 && userId <= 5)
        {
            var userInfoConfig = context.RequestServices.GetRequiredService<IConfiguration>().GetSection($"Users:{userId}");

            context.Response.WriteAsync($"User information for id {userId}:\n");
            context.Response.WriteAsync($"Name: {userInfoConfig["Name"]}\n");
            context.Response.WriteAsync($"Age: {userInfoConfig["Age"]}\n");
            context.Response.WriteAsync($"Email: {userInfoConfig["Email"]}\n");
        }
        else
        {
            var userInfoConfig = context.RequestServices.GetRequiredService<IConfiguration>().GetSection($"Users:self");

            context.Response.WriteAsync($"User information\n");
            context.Response.WriteAsync($"Name: {userInfoConfig["Name"]}\n");
            context.Response.WriteAsync($"Age: {userInfoConfig["Age"]}\n");
            context.Response.WriteAsync($"Email: {userInfoConfig["Email"]}\n");
        }
    }
}

