using System.Data.Entity;

namespace WarehouseManagement.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("WarehouseManagement")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ComputerComponents> ComputerComponents { get; set; }

        public DbSet<TypeOfSubassembly> TypeOfSubassemblies { get; set; }
    }
}