namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServerDatabases", "EmployeeId", c => c.Int());
            CreateIndex("dbo.ServerDatabases", "EmployeeId");
            AddForeignKey("dbo.ServerDatabases", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerDatabases", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ServerDatabases", new[] { "EmployeeId" });
            DropColumn("dbo.ServerDatabases", "EmployeeId");
        }
    }
}
