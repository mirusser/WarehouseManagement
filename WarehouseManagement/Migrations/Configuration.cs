namespace WarehouseManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WarehouseManagement.Models;
    using WarehouseManagement.Models.Context;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.TypeOfSubassemblies.AddOrUpdate(x => x.Id,
                new TypeOfSubassembly() { Id = 1, Name = "Graphic Card" },
                new TypeOfSubassembly() { Id = 2, Name = "Processor" },
                new TypeOfSubassembly() { Id = 3, Name = "Motherboard" },
                new TypeOfSubassembly() { Id = 4, Name = "Hard Drive" }
                );
        }
    }
}
