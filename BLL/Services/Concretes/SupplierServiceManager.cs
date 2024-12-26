using BLL.Services.Abstracts;
using DAL.Repositories.Abstracts;
using MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class SupplierServiceManager : ServiceManager<Supplier>, ISupplierServiceManager
    {
        public SupplierServiceManager(IRepository<Supplier> repository) : base(repository)
        {
        }
    }
}
