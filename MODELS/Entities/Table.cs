using MODELS.Abstracts;
using MODELS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Table:BaseEntity
    {
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public TableStatus TableStatus { get; set; }

        //relationship

        public List<Reservation> Reservations { get; set; } // Masya birden fazla rez(müşteri) gelir.
        public List<Order> Orders { get; set; }//Masaya birden falzla sipariş gelir
        public Employee Employee { get; set; } // Masaya rez bir çalışan tarafından yapılır
        public int EmployeeId { get; set; }

    }
}
