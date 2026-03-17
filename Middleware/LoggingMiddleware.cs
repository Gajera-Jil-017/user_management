using System.Diagnostics;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();

        await _next(context);

        watch.Stop();
        Console.WriteLine($"Request took {watch.ElapsedMilliseconds} ms");
    }
}