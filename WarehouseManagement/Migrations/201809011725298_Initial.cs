namespace WarehouseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComputerComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatalogNumber = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        TypeOfSubassemblyId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 100),
                        Barcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfSubassemblies", t => t.TypeOfSubassemblyId, cascadeDelete: true)
                .Index(t => t.TypeOfSubassemblyId);
            
            CreateTable(
                "dbo.TypeOfSubassemblies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComputerComponents", "TypeOfSubassemblyId", "dbo.TypeOfSubassemblies");
            DropIndex("dbo.ComputerComponents", new[] { "TypeOfSubassemblyId" });
            DropTable("dbo.TypeOfSubassemblies");
            DropTable("dbo.ComputerComponents");
        }
    }
}
