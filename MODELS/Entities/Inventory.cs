using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Inventory:BaseEntity
    {
        public int QuantityInStock { get; set; }        // Mevcut stok miktarı
        public int ReorderLevel { get; set; }           // Yeniden sipariş seviyesi
        public int ReorderQuantity { get; set; }        // Yeniden sipariş miktarı
        public DateTime? LastRestockDate { get; set; }  // En son stoklama tarihi
     


        // Relationships
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public Employee Employee { get; set; } // depodan sorumlu personel için ilişki
        public int EmployeeId { get; set; }
    }
}
