namespace FInspectData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelbuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinalInspectionUploads", "FinalInspection_Id", "dbo.FinalInspections");
            AddForeignKey("dbo.FinalInspectionUploads", "FinalInspection_Id", "dbo.FinalInspections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinalInspectionUploads", "FinalInspection_Id", "dbo.FinalInspections");
            AddForeignKey("dbo.FinalInspectionUploads", "FinalInspection_Id", "dbo.FinalInspections", "Id");
        }
    }
}
