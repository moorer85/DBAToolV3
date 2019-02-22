namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServerDatabases", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.ServerDatabases", "Employee_EmployeeId");
            AddForeignKey("dbo.ServerDatabases", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServerDatabases", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.ServerDatabases", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.ServerDatabases", "Employee_EmployeeId");
        }
    }
}
