using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Models.Context;

namespace WarehouseManagement.Logic.Factories.Interfaces
{
    public interface IRepositoryFactory : IFactory
    {
        //Any additional method here
        T Get<T>(ApplicationDbContext context);
    }
}
