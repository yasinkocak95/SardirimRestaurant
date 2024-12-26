using MODELS.Abstracts;
using MODELS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Payment:BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        
        
        //relationship
        public int OrderId { get; set; }
        public Order Order { get; set; }   //Ödeme bir siparişe ait olmalı

        public int CustomerId { get; set; } // 
        public Customer Customer { get; set; } //ödeme bir müşteriye ait 
    }
}
