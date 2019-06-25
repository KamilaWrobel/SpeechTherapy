namespace SpeechTherapy.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTheraphistForClient : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clients", new[] { "TherapistId" });
            AlterColumn("dbo.Clients", "TherapistId", c => c.Int());
            CreateIndex("dbo.Clients", "TherapistId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clients", new[] { "TherapistId" });
            AlterColumn("dbo.Clients", "TherapistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "TherapistId");
        }
    }
}
