var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseMiddleware<Company>("Skynet", 1988);


app.Run();
