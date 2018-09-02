using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseManagement.Models;
using WarehouseManagement.Models.Context;
using WarehouseManagement.Logic.Repositories.Interfaces;

namespace WarehouseManagement.Logic.Repositories
{
    public class ComputerComponentsRepository : BaseRepository<ComputerComponents, ApplicationDbContext>, IComputerComponentsRepository
    {
        public ComputerComponentsRepository()
        {

        }

        public ComputerComponentsRepository(ApplicationDbContext entities) : base(entities)
        {

        }

    }
}