namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServerDatabases", "BackupDBA_Id", "dbo.Employees");
            DropForeignKey("dbo.ServerDatabases", "PrimaryDBA_Id", "dbo.Employees");
            DropIndex("dbo.ServerDatabases", new[] { "BackupDBA_Id" });
            DropIndex("dbo.ServerDatabases", new[] { "PrimaryDBA_Id" });
            DropPrimaryKey("dbo.Employees");
             DropColumn("dbo.Employees", "Id");
            DropColumn("dbo.ServerDatabases", "BackupDBA_Id");
            DropColumn("dbo.ServerDatabases", "PrimaryDBA_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServerDatabases", "PrimaryDBA_Id", c => c.Int());
            AddColumn("dbo.ServerDatabases", "BackupDBA_Id", c => c.Int());
            AddColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmployeeId");
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.ServerDatabases", "PrimaryDBA_Id");
            CreateIndex("dbo.ServerDatabases", "BackupDBA_Id");
            AddForeignKey("dbo.ServerDatabases", "PrimaryDBA_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.ServerDatabases", "BackupDBA_Id", "dbo.Employees", "Id");
        }
    }
}
