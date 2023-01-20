using AutoMapper;
using KatmanliMimariApi.Api.Filters;
using KatmanlıMimariApi.Core.Dtos;
using KatmanlıMimariApi.Core.Models;
using KatmanlıMimariApi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliMimariApi.Api.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly IProductService _service;
        public ProductsController(IMapper mapper,IProductService productService)
        {
            _mapper=mapper;
           
            _service = productService;

        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products= await _service.GetAllAsync();
            var productsDtos=_mapper.Map<List<ProductDto>>(products.ToList());
            // return Ok(CustomResponseDto<List<Product>>.Succes(200,productsDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succes(200, productsDtos));
           
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {

            return CreateActionResult(await _service.GetProductWithCategory());

        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(200, productsDtos));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var products = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDtos = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(201, productsDtos));

        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDto updateDto)
        {
             await _service.UpdateAsync(_mapper.Map<Product>(updateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));

        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));

        }
    }
}
