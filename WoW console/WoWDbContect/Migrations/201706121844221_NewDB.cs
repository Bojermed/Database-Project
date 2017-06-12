namespace WoWDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "FactionId", c => c.Int());
            CreateIndex("dbo.Races", "FactionId");
            AddForeignKey("dbo.Races", "FactionId", "dbo.Factions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "FactionId", "dbo.Factions");
            DropIndex("dbo.Races", new[] { "FactionId" });
            DropColumn("dbo.Races", "FactionId");
        }
    }
}
