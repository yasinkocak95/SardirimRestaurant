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
    public class ProductServiceManager : ServiceManager<Product>, IProductServiceManager
    {
        public ProductServiceManager(IRepository<Product> repository) : base(repository)
        {
        }
    }
}
