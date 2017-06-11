namespace WoWPostgreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkforchanges : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cities", "Name", unique: true, name: "CountryIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cities", "CountryIndex");
        }
    }
}
