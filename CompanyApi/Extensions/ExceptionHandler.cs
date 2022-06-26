using Microsoft.AspNetCore.Diagnostics;
using ILogger = Contracts.ILogger;

namespace CompanyApi.Extensions;

public static class ExceptionHandler
{
   public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
   {
      app.UseExceptionHandler(builder => builder.Run(async context =>
      {
         context.Response.StatusCode = StatusCodes.Status500InternalServerError;
         context.Response.Headers.ContentType = "application/json";
         var features = context.Features.Get<IExceptionHandlerFeature>();
         logger.LogError($"Internal server error: {features?.Error.Message}");
         await context.Response.WriteAsJsonAsync(new
         {
            ErrorMessage = features?.Error.Message ?? "Internal Server Error",
            Trace = features?.Error.StackTrace
         });
      }));
   } 
}