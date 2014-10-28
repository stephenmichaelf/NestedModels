namespace NestedModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Extensions",
                c => new
                    {
                        ExtensionId = c.Int(nullable: false, identity: true),
                        Count = c.String(),
                        ExtensionDetails_ExtensionDetailsId = c.Int(),
                        Phone_PhoneId = c.Int(),
                    })
                .PrimaryKey(t => t.ExtensionId)
                .ForeignKey("dbo.ExtensionDetails", t => t.ExtensionDetails_ExtensionDetailsId)
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneId)
                .Index(t => t.ExtensionDetails_ExtensionDetailsId)
                .Index(t => t.Phone_PhoneId);
            
            CreateTable(
                "dbo.ExtensionDetails",
                c => new
                    {
                        ExtensionDetailsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ExtensionDetailsId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Extensions", new[] { "Phone_PhoneId" });
            DropIndex("dbo.Extensions", new[] { "ExtensionDetails_ExtensionDetailsId" });
            DropForeignKey("dbo.Extensions", "Phone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Extensions", "ExtensionDetails_ExtensionDetailsId", "dbo.ExtensionDetails");
            DropTable("dbo.ExtensionDetails");
            DropTable("dbo.Extensions");
        }
    }
}
