namespace WoWPostgreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Characters", "Users_Id", c => c.Int());
            AlterColumn("dbo.Cities", "CountriesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "CitiesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CitiesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "CountriesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Characters", "Users_Id", c => c.Int());
        }
    }
}
