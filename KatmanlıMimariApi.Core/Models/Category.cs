using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanlıMimariApi.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        //Suppose there is more than one category. 
        //Navigation Property
        public ICollection<Product> Products { get; set; }

    }
}
