namespace FInspectData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelbuilderuploads : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FinalInspectionUploads", new[] { "FinalInspection_Id" });
            AlterColumn("dbo.FinalInspectionUploads", "FinalInspection_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.FinalInspectionUploads", "FinalInspection_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FinalInspectionUploads", new[] { "FinalInspection_Id" });
            AlterColumn("dbo.FinalInspectionUploads", "FinalInspection_Id", c => c.Int());
            CreateIndex("dbo.FinalInspectionUploads", "FinalInspection_Id");
        }
    }
}
