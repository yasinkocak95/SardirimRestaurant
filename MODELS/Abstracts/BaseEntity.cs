using MODELS.Enums;
using MODELS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MODELS.Abstracts
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            GuidId = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            CreatedComputerName = System.Environment.MachineName;
            CreatedIpAddress = IpAdress.GetIPAddress();
            IsActive = true;

        }
        public int ID { get; set; }
        public string GuidId { get; set; }

        //Created Propertiesjn jn bgfv
        public DateTime? CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }

        //Updated Properties
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }

        //

        public bool IsActive { get; set; }

    }
}
