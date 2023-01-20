using AutoMapper;
using KatmanlıMimariApi.Core.Dtos;
using KatmanlıMimariApi.Core.Models;
using KatmanlıMimariApi.Core.Repositories;
using KatmanlıMimariApi.Core.Services;
using KatmanlıMimariApi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariApi.Services.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository,IMapper mapper, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int categoryid)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryid);
            var categoryDto=_mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Succes(200,categoryDto);
        }
    }
}
