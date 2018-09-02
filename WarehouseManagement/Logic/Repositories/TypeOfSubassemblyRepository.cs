using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Logic.Repositories.Interfaces;
using WarehouseManagement.Models;
using WarehouseManagement.Models.Context;

namespace WarehouseManagement.Logic.Repositories
{
    public class TypeOfSubassemblyRepository : BaseRepository<TypeOfSubassembly, ApplicationDbContext>, ITypeOfSubassemblyRepository
    {
        public TypeOfSubassemblyRepository()
        {

        }

        public TypeOfSubassemblyRepository(ApplicationDbContext entities) : base(entities)
        {

        }
    }
}
