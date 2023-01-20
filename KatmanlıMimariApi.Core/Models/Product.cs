using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanlıMimariApi.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        //Suppose you belong to one Category
        public Category Category { get; set; }
        //one to one relationship
        public ProductFeature ProductFeature { get; set; }

    }
}
