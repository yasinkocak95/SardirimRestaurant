using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Entities
{
    public class User:IdentityUser
    {


        //relationship

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
