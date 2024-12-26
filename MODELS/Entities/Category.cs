using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }


        //relationship

        public List<Product> Products { get; set; }
    }
}
