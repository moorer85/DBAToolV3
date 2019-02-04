namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServerDatabases", "Server_Id", "dbo.Servers");
            DropIndex("dbo.ServerDatabases", new[] { "Server_Id" });
            RenameColumn(table: "dbo.ServerDatabases", name: "Server_Id", newName: "ServerId");
            AlterColumn("dbo.ServerDatabases", "ServerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServerDatabases", "ServerId");
            AddForeignKey("dbo.ServerDatabases", "ServerId", "dbo.Servers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerDatabases", "ServerId", "dbo.Servers");
            DropIndex("dbo.ServerDatabases", new[] { "ServerId" });
            AlterColumn("dbo.ServerDatabases", "ServerId", c => c.Int());
            RenameColumn(table: "dbo.ServerDatabases", name: "ServerId", newName: "Server_Id");
            CreateIndex("dbo.ServerDatabases", "Server_Id");
            AddForeignKey("dbo.ServerDatabases", "Server_Id", "dbo.Servers", "Id");
        }
    }
}
