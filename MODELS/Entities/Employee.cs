using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        //relationship

        public List<Order> Orders { get; set; }  // Bir çalışan birçok siparişle ilgilenebilir
        public List<Table> Tables { get; set; } //Personel tarafından atanan masa personel olarak
        public List<Inventory> Inventories { get; set; } // Stoklamadan sorumlu
        public List<Reservation> Reservations { get; set; } //Bir çalışan birden fazla rezervasyonu işleyebilir
        public List<Supplier> Suppliers { get; set; } // İletişim kurduğu tedarikçiler

        //public string UserId { get; set; } //IdentityUserda ıdler string.
        //public User User { get; set; }

    }
}
