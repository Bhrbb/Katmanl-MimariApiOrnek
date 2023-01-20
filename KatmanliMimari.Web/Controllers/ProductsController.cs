using KatmanlıMimariApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliMimari.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var CustomResponse = await _productService.GetProductWithCategory();

            return View(CustomResponse);
        }
    }
}
