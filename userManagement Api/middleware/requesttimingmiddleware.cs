using System.Diagnostics;

namespace UserApi.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            Console.WriteLine($"[{DateTime.UtcNow}] {context.Request.Method} {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
