namespace NetCoreAPI.WebAPI.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MyMiddleware> _logger;
        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger)
        {
            _next = next;
            _logger = logger;

          
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing.


            if (context.Request.Headers.ContainsKey("x-api-key"))
            {
                _logger.LogInformation("x-api-key header found");
            }
            else
            {
                _logger.LogInformation("x-api-key header not found");
            }

            _logger.LogInformation("MyMiddleware is invoked");

            await _next(context);
            // Clean up.
        }
    }
}
