using AutoMapper;
using KatmanlıMimariApi.Core.Dtos;
using KatmanlıMimariApi.Core.Models;
using KatmanlıMimariApi.Core.Repositories;
using KatmanlıMimariApi.Core.Services;
using KatmanlıMimariApi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariApi.Services.Services
{
    public class ProductServiceWithCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository   _productrepository;
        private readonly IMapper _mapper;
        public ProductServiceWithCaching(IGenericRepository<Product> repository,IMapper mapper, IProductRepository productrepository, IUnitOfWork unitOfWork):base(repository,unitOfWork)
        {
            _productrepository= productrepository;
            _mapper= mapper;
        }
        public async Task<List<ProductWithCategoryDto>> GetProductWithCategory()
        {
           var products=await _productrepository.GetProductWithCategory();
            var productsDto= _mapper.Map<List<ProductWithCategoryDto>>(products);
            return productsDto;
        }
    }
}
