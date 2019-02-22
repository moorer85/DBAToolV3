namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServerDatabases", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.ServerDatabases", new[] { "Employee_EmployeeId" });
           // DropColumn("dbo.ServerDatabases", "PrimaryDBAId");
           // DropColumn("dbo.ServerDatabases", "Employee_EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServerDatabases", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.ServerDatabases", "PrimaryDBAId", c => c.Int());
            CreateIndex("dbo.ServerDatabases", "Employee_EmployeeId");
            AddForeignKey("dbo.ServerDatabases", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
    }
}
