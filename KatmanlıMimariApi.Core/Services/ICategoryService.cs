using KatmanlıMimariApi.Core.Dtos;
using KatmanlıMimariApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanlıMimariApi.Core.Services
{
    public interface ICategoryService:IServices<Category>
    {
       public  Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int categoryid);

    }
}
