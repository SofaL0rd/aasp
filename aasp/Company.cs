public class Company
{
    private readonly RequestDelegate next;
    private readonly string name;
    private readonly int yearFounded;

    public Company(RequestDelegate next, string name, int yearFounded)
    {
        this.next = next;
        this.name = name;
        this.yearFounded = yearFounded;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var random = new Random();
        var randNum = random.Next(0, 101);

        await context.Response.WriteAsync($"Random number: {randNum}\n");
        await context.Response.WriteAsync($"Company:{name} , Year Founded:{yearFounded} ");
    }
}