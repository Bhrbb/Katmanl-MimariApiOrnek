using KatmanlıMimariApi.Core.Dtos;
using KatmanliMimariApi.Services.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace KatmanliMimariApi.Api.Middleware
{
    public static class UseCustomExceptionHandler
    {//Middleware incoming request is output as a request with certain rules 
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //run equals terminating method 
            //if there is an exception , request is backs
            app.UseExceptionHandler(configure =>
            {

                configure.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideExceptions => 400,
                        NotFoundException=>404,
                        _ => 500

                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Error(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
