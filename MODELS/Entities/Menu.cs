using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Menu:BaseEntity
    {
        public string MenuName { get; set; }
        public string Description { get; set; }

        //relationship

        public List<Product> Products { get; set; } //her menü birden fazla üründen oluşur
    }
}
