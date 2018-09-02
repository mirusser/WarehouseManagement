using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Logic.Factories.Interfaces
{
    public interface IFactory
    {
        T Get<T>();
    }
}
