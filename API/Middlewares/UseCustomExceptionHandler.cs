using Core.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Service.Exceptions;
using System.Text.Json;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var excFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = excFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundExtensions => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response =  CustomResponseDto<NoContentDto>.Fail(statusCode,excFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
