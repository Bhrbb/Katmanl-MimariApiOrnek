using KatmanlıMimariApi.Core.Dtos;
using KatmanlıMimariApi.Core.Models;
using KatmanlıMimariApi.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KatmanliMimariApi.Api.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IServices<T> _services;
        //mesela data olmayan bır veri cekmeye calısıyorsun busines katmanında tek tek kod yazmak yerıne bu sınıfı olusturup controllerda belırtırsın 
       //busınes kodu cogaltmamak ıcın
       //[ServiceFilter(typeof(NotFoundFilter<Product>))]
       //daha metoda gırmeden en basta hata fırlatıp gerı donuuor 
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue==null)
            {
                await next.Invoke();//Contuinue in here 
            }
            var id = (int)idValue;
            var anyEntity = await _services.AnyAsync(x=>x.Id==id);
            if (anyEntity)
            {
                await next.Invoke();
                return;

            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Error(400, $"{typeof(T).Name}({id}) not found"));
        }
    }
}
