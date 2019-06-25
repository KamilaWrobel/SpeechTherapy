namespace SpeechTherapy.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "StatusName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "StatusName");
        }
    }
}
