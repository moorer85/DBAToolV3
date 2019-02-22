namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bg1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServerDatabases", "BackupDBA_Id", c => c.Int());
            AddColumn("dbo.ServerDatabases", "PrimaryDBA_Id", c => c.Int());
            CreateIndex("dbo.ServerDatabases", "BackupDBA_Id");
            CreateIndex("dbo.ServerDatabases", "PrimaryDBA_Id");
            AddForeignKey("dbo.ServerDatabases", "BackupDBA_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.ServerDatabases", "PrimaryDBA_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerDatabases", "PrimaryDBA_Id", "dbo.Employees");
            DropForeignKey("dbo.ServerDatabases", "BackupDBA_Id", "dbo.Employees");
            DropIndex("dbo.ServerDatabases", new[] { "PrimaryDBA_Id" });
            DropIndex("dbo.ServerDatabases", new[] { "BackupDBA_Id" });
            DropColumn("dbo.ServerDatabases", "PrimaryDBA_Id");
            DropColumn("dbo.ServerDatabases", "BackupDBA_Id");
        }
    }
}
