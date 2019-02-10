namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServerDatabases", "ServerId", "dbo.Servers");
            DropIndex("dbo.ServerDatabases", new[] { "ServerId" });
            AlterColumn("dbo.ServerDatabases", "ServerId", c => c.Int());
            CreateIndex("dbo.ServerDatabases", "ServerId");
            AddForeignKey("dbo.ServerDatabases", "ServerId", "dbo.Servers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerDatabases", "ServerId", "dbo.Servers");
            DropIndex("dbo.ServerDatabases", new[] { "ServerId" });
            AlterColumn("dbo.ServerDatabases", "ServerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServerDatabases", "ServerId");
            AddForeignKey("dbo.ServerDatabases", "ServerId", "dbo.Servers", "Id", cascadeDelete: true);
        }
    }
}
