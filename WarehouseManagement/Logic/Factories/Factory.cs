using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseManagement.Logic.Factories.Interfaces;

namespace WarehouseManagement.Logic.Factories
{
    public abstract class Factory : IFactory
    {
        protected virtual bool CheckIfImplementsInterface<T, TInterface>()
        {
            var assignableType = typeof(TInterface);

            if (!typeof(T).GetInterfaces().Contains(assignableType))
            {
                var errorMessage = $"{nameof(T)} not implementing {nameof(assignableType)}";
                throw new NotImplementedException(errorMessage);
            }
            return true;
        }

        public abstract T Get<T>();
    }
}