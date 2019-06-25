namespace SpeechTherapy.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Therapists", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Therapists", "IsDeleted");
            DropColumn("dbo.Clients", "IsDeleted");
        }
    }
}
