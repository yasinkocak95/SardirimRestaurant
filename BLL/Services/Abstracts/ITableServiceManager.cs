using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table = MODELS.Entities.Table;

namespace BLL.Services.Abstracts
{
    public interface ITableServiceManager:IServiceManager<Table>
    {
    }
}
