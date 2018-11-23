namespace FInspectData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalInspectionUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attachment = c.String(),
                        FinalInspection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinalInspections", t => t.FinalInspection_Id)
                .Index(t => t.FinalInspection_Id);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nonconformances", "Inspector_Id", "dbo.Inspectors");
            DropForeignKey("dbo.FinalInspections", "Inspector_Id", "dbo.Inspectors");
            DropForeignKey("dbo.FinalInspectionUploads", "FinalInspection_Id", "dbo.FinalInspections");
            DropIndex("dbo.Nonconformances", new[] { "Inspector_Id" });
            DropIndex("dbo.FinalInspectionUploads", new[] { "FinalInspection_Id" });
            DropIndex("dbo.FinalInspections", new[] { "Inspector_Id" });
            DropTable("dbo.Nonconformances");
            DropTable("dbo.MiStatusTransactions");
            DropTable("dbo.Inspectors");
            DropTable("dbo.FinalInspectionUploads");
            DropTable("dbo.FinalInspections");
            DropTable("dbo.Assemblies");
        }
    }
}
