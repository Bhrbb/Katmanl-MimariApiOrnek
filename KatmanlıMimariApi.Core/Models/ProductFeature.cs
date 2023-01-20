using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanlıMimariApi.Core.Models
{
    public class ProductFeature
    {

        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
        //one-to-one relationship
        public Product Product { get; set; }

    }
}
