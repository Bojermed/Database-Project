namespace WoWPostgreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduniqueconstrains : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Characters", "Name", unique: true, name: "NameIndex");
            CreateIndex("dbo.Users", "Email", unique: true, name: "EmailIndex");
            CreateIndex("dbo.Countries", "Name", unique: true, name: "CityIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Countries", "CityIndex");
            DropIndex("dbo.Users", "EmailIndex");
            DropIndex("dbo.Characters", "NameIndex");
        }
    }
}
