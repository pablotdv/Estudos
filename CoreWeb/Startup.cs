using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Startup
{
    public void ConfiureServices(IServiceCollection services)
    {

    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(minLevel: LogLevel.Information);
        var logger = loggerFactory.CreateLogger(env.EnvironmentName);
        app.Use(async (context, next) =>
        {
            logger.LogInformation("Handling request.");
            await next.Invoke();
            logger.LogInformation("Finished handling request.");
        });

        app.Run(async context =>
        {
            await context.Response.WriteAsync("Hello from " + env.EnvironmentName);
        });
    }
}