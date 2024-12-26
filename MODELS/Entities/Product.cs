using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        



        //relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } // OrderProduct aracılığıyla Sipariş ile çoktan çoğa ilişki
        public List<Inventory> Inventories { get; set; } // Bir ürün bir envantere ait olabilir

        public int SupplierId { get; set; } 
        public Supplier Supplier { get; set; } //Bir ürün bir tedarikçiden gelir

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }


}


