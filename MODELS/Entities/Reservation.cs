using MODELS.Abstracts;
using MODELS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Reservation:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }


        //relationship

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  // Rezervasyon bir müşteri tarafından yapılır
        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }  // Rezervasyon bir çalışan tarafından işlenir

        public int TableId { get; set; }  // Her rezervasyonun bir masası olur
        public Table Table { get; set; }


    }
}
