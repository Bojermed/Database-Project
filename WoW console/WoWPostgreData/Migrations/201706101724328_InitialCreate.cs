namespace WoWPostgreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        CountriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountriesId, cascadeDelete: true)
                .Index(t => t.CountriesId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        PasswordHash = c.String(nullable: false, maxLength: 30),
                        CitiesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CitiesId, cascadeDelete: true)
                .Index(t => t.CitiesId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountriesId", "dbo.Countries");
            DropForeignKey("dbo.Users", "CitiesId", "dbo.Cities");
            DropForeignKey("dbo.Characters", "Users_Id", "dbo.Users");
            DropIndex("dbo.Cities", new[] { "CountriesId" });
            DropIndex("dbo.Users", new[] { "CitiesId" });
            DropIndex("dbo.Characters", new[] { "Users_Id" });
            DropTable("dbo.Countries");
            DropTable("dbo.Users");
            DropTable("dbo.Cities");
            DropTable("dbo.Characters");
        }
    }
}
