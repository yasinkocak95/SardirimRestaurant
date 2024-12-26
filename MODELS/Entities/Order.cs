using MODELS.Abstracts;
using MODELS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }


        //relationship

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  //Bir sipariş bir müşteriye ait olmalı

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }  //Sipariş bir çalışan tarafından işlenmiş olabilir

        public List<OrderProduct> OrderProducts { get; set; }  // OrderProduct aracılığıyla Ürün ile çoktan çoğa ilişki

        public int TableId { get; set; }
        public Table Table { get; set; } //Sipariş bir masaya aittir

        public int PaymentId { get; set; }
        public Payment Payment { get; set; } // ödeme bir sipariie ait


    }
}
