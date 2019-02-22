namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h9 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ServerDatabases", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameIndex(table: "dbo.ServerDatabases", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ServerDatabases", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameColumn(table: "dbo.ServerDatabases", name: "EmployeeId", newName: "Employee_EmployeeId");
        }
    }
}
