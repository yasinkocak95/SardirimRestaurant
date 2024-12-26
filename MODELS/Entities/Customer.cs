using MODELS.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Customer:BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        //relationship

        public List<Order> Orders { get; set; }   // Bir müşteri birçok siparişe sahip olabilir
        public List<Reservation> Reservations { get; set; }
        public List<Payment> Payments { get; set; }

    }
}
