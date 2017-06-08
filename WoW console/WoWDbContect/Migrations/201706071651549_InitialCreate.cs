namespace WoWDbContect.Migrations
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
                        PlayerId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        FactionId = c.Int(nullable: false),
                        ProfessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factions", t => t.FactionId, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.RaceId)
                .Index(t => t.ClassId)
                .Index(t => t.FactionId)
                .Index(t => t.ProfessionId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ResourceId = c.Int(nullable: false),
                        Lore = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Language = c.String(maxLength: 20),
                        Location = c.String(storeType: "ntext"),
                        Capital = c.String(maxLength: 20),
                        Mount = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Npcs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Titles = c.String(storeType: "ntext"),
                        Health = c.Int(),
                        GenderId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        FactionId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        ZoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Factions", t => t.FactionId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Statuses", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.RaceId)
                .Index(t => t.ClassId)
                .Index(t => t.FactionId)
                .Index(t => t.StatusId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ContinentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continents", t => t.ContinentId, cascadeDelete: true)
                .Index(t => t.ContinentId);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        PlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.PlanetId, cascadeDelete: true)
                .Index(t => t.PlanetId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        PasswordHash = c.String(nullable: false, maxLength: 30),
                        Servers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ProfessionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RacesClasses",
                c => new
                    {
                        Races_Id = c.Int(nullable: false),
                        Classes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Races_Id, t.Classes_Id })
                .ForeignKey("dbo.Races", t => t.Races_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Classes_Id, cascadeDelete: true)
                .Index(t => t.Races_Id)
                .Index(t => t.Classes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Characters", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.Characters", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Characters", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.Npcs", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Zones", "ContinentId", "dbo.Continents");
            DropForeignKey("dbo.Continents", "PlanetId", "dbo.Planets");
            DropForeignKey("dbo.Npcs", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.Npcs", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Npcs", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Npcs", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.Characters", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.Npcs", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.RacesClasses", "Classes_Id", "dbo.Classes");
            DropForeignKey("dbo.RacesClasses", "Races_Id", "dbo.Races");
            DropIndex("dbo.RacesClasses", new[] { "Classes_Id" });
            DropIndex("dbo.RacesClasses", new[] { "Races_Id" });
            DropIndex("dbo.Continents", new[] { "PlanetId" });
            DropIndex("dbo.Zones", new[] { "ContinentId" });
            DropIndex("dbo.Npcs", new[] { "ZoneId" });
            DropIndex("dbo.Npcs", new[] { "StatusId" });
            DropIndex("dbo.Npcs", new[] { "FactionId" });
            DropIndex("dbo.Npcs", new[] { "ClassId" });
            DropIndex("dbo.Npcs", new[] { "RaceId" });
            DropIndex("dbo.Npcs", new[] { "GenderId" });
            DropIndex("dbo.Classes", new[] { "ResourceId" });
            DropIndex("dbo.Characters", new[] { "ProfessionId" });
            DropIndex("dbo.Characters", new[] { "FactionId" });
            DropIndex("dbo.Characters", new[] { "ClassId" });
            DropIndex("dbo.Characters", new[] { "RaceId" });
            DropIndex("dbo.Characters", new[] { "PlayerId" });
            DropTable("dbo.RacesClasses");
            DropTable("dbo.Professions");
            DropTable("dbo.Players");
            DropTable("dbo.Resources");
            DropTable("dbo.Planets");
            DropTable("dbo.Continents");
            DropTable("dbo.Zones");
            DropTable("dbo.Statuses");
            DropTable("dbo.Genders");
            DropTable("dbo.Factions");
            DropTable("dbo.Npcs");
            DropTable("dbo.Races");
            DropTable("dbo.Classes");
            DropTable("dbo.Characters");
        }
    }
}
