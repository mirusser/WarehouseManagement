using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Logic.Managers.Interfaces;
using WarehouseManagement.Models;

namespace WarehouseManagement.Logic.Managers.Interfaces
{
    public interface IComputerComponentsManager : IManager
    {
        ComputerComponents Add(ComputerComponents computerComponents);
        ComputerComponents Modify(ComputerComponents computerComponents);
        void Delete(ComputerComponents computerComponents);
        ComputerComponents GetById(int id);
        IQueryable<ComputerComponents> GetAll();
        List<TypeOfSubassembly> GetTypeOfSubassemblies();
        void Dispose();
    }
}
