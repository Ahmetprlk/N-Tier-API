using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class NotFounFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> service ;

        public NotFounFilter(IService<T> service)
        {
            this.service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var IdValue = context.ActionArguments.Values.FirstOrDefault();
            if (IdValue != null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)IdValue;
            var anyentity = await service.AnyAsync(x =>x.ID==id);

            if ( anyentity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404,
                $"{typeof(T).Name} Not Found"));
        }
    }
}
