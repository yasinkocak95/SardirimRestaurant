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
    public class MenuServiceManager : ServiceManager<Menu>, IMenuServiceManager
    {
        public MenuServiceManager(IRepository<Menu> repository) : base(repository)
        {
        }
    }
}
