using KatmanlıMimariApi.Core.Models;
using KatmanlıMimariApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariApi.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }
       

        public async Task<Category> GetCategoryByIdWithProductsAsync(int categoryid)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id==categoryid).SingleOrDefaultAsync();
        }
    }
}
