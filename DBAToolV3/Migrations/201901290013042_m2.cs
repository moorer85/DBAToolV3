namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServerDatabases", "Server_Id", c => c.Int());
            CreateIndex("dbo.ServerDatabases", "Server_Id");
            AddForeignKey("dbo.ServerDatabases", "Server_Id", "dbo.Servers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerDatabases", "Server_Id", "dbo.Servers");
            DropIndex("dbo.ServerDatabases", new[] { "Server_Id" });
            DropColumn("dbo.ServerDatabases", "Server_Id");
        }
    }
}
