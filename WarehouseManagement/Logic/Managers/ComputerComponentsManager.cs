using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseManagement.Logic.Factories.Interfaces;
using WarehouseManagement.Logic.Managers.Interfaces;
using WarehouseManagement.Logic.Repositories;
using WarehouseManagement.Logic.Repositories.Interfaces;
using WarehouseManagement.Models;

namespace WarehouseManagement.Logic.Managers
{
    public class ComputerComponentsManager : IComputerComponentsManager
    {
        #region Properties
        private readonly IComputerComponentsRepository computerComponentsRepository;
        private readonly ITypeOfSubassemblyRepository typeOfSubassemblyRepository;
        #endregion

        #region Constructors
        public ComputerComponentsManager() { }

        public ComputerComponentsManager(IRepositoryFactory repositoryFactory)
        {
            computerComponentsRepository = repositoryFactory.Get<ComputerComponentsRepository>();
            typeOfSubassemblyRepository = repositoryFactory.Get<TypeOfSubassemblyRepository>();
        }
        #endregion

        public ComputerComponents Add(ComputerComponents computerComponents)
        {
            if (computerComponents == null || GetById(computerComponents.Id) != null)
            {
                return null;
            }

            computerComponentsRepository.Add(computerComponents);
            computerComponentsRepository.Save();
            return computerComponents;
        }

        public ComputerComponents Modify(ComputerComponents computerComponents)
        {
            if (computerComponents != null)
            {
                var computerComponentsToModify = GetById(computerComponents.Id);
                var typeOfSubassembly = typeOfSubassemblyRepository.GetById(computerComponents.TypeOfSubassemblyId);


                computerComponentsToModify.Name = computerComponents.Name;
                computerComponentsToModify.CatalogNumber = computerComponents.CatalogNumber;
                computerComponentsToModify.TypeOfSubassembly = typeOfSubassembly;
                computerComponentsToModify.TypeOfSubassemblyId = typeOfSubassembly.Id;
                computerComponentsToModify.Model = computerComponents.Model;
                computerComponentsToModify.Barcode = computerComponents.Barcode;

                computerComponentsRepository.Save();

                return computerComponentsToModify;
            }
            return null;
        }

        public void Delete(ComputerComponents computerComponents)
        {
            if (computerComponents != null)
            {
                computerComponentsRepository.Delete(computerComponents);
                computerComponentsRepository.Save();
            }
        }


        public ComputerComponents GetById(int id)
        {
            return computerComponentsRepository.GetById(id);
        }

        public IQueryable<ComputerComponents> GetAll()
        {
            return computerComponentsRepository.GetAll();
        }

        public List<TypeOfSubassembly> GetTypeOfSubassemblies()
        {
            return typeOfSubassemblyRepository.GetAll().ToList();
        }

        public void Dispose()
        {
            computerComponentsRepository.Dispose();
        }
    }
}