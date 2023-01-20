using KatmanliMimariApi.Api.Filters;
using KatmanlıMimariApi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KatmanliMimariApi.Api.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryid}")]
        //api//categories//GetCategoryByIdWithProductsAsync/2
        public async  Task<IActionResult> GetCategoryByIdWithProductsAsync(int categoryid)
        {
            return CreateActionResult(await _categoryService.GetCategoryByIdWithProductsAsync(categoryid)); 
        }


    }
}
