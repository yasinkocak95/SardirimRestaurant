using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactFullName { get; set; }
        public string PhoneNumber { get; set; }




        // Relationships
        public List<Product> Products { get; set; } //  Bir tedarikçi birden fazla ürün sağlayabilir
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
