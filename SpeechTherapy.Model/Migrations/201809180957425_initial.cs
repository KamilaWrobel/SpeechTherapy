namespace SpeechTherapy.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        TherapistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Therapists", t => t.TherapistId)
                .Index(t => t.TherapistId);
            
            CreateTable(
                "dbo.Therapies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        TherapistId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Therapists", t => t.TherapistId)
                .Index(t => t.TherapistId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Therapists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "TherapistId", "dbo.Therapists");
            DropForeignKey("dbo.Therapies", "TherapistId", "dbo.Therapists");
            DropForeignKey("dbo.Therapies", "ClientId", "dbo.Clients");
            DropIndex("dbo.Therapies", new[] { "ClientId" });
            DropIndex("dbo.Therapies", new[] { "TherapistId" });
            DropIndex("dbo.Clients", new[] { "TherapistId" });
            DropTable("dbo.Therapists");
            DropTable("dbo.Therapies");
            DropTable("dbo.Clients");
        }
    }
}
