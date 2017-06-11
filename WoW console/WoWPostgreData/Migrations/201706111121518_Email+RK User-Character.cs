namespace WoWPostgreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailRKUserCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "UserId");
        }
    }
}
