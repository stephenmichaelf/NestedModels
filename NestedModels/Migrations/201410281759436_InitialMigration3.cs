namespace NestedModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Extensions", "ExtensionDetails_ExtensionDetailsId", "dbo.ExtensionDetails");
            DropIndex("dbo.Extensions", new[] { "ExtensionDetails_ExtensionDetailsId" });
            RenameColumn(table: "dbo.Extensions", name: "ExtensionDetails_ExtensionDetailsId", newName: "ExtensionDetailsId");
            AddForeignKey("dbo.Extensions", "ExtensionDetailsId", "dbo.ExtensionDetails", "ExtensionDetailsId", cascadeDelete: true);
            CreateIndex("dbo.Extensions", "ExtensionDetailsId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Extensions", new[] { "ExtensionDetailsId" });
            DropForeignKey("dbo.Extensions", "ExtensionDetailsId", "dbo.ExtensionDetails");
            RenameColumn(table: "dbo.Extensions", name: "ExtensionDetailsId", newName: "ExtensionDetails_ExtensionDetailsId");
            CreateIndex("dbo.Extensions", "ExtensionDetails_ExtensionDetailsId");
            AddForeignKey("dbo.Extensions", "ExtensionDetails_ExtensionDetailsId", "dbo.ExtensionDetails", "ExtensionDetailsId");
        }
    }
}
