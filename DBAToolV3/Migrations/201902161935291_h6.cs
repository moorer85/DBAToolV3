namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ServerDatabases", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameIndex(table: "dbo.ServerDatabases", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            AddColumn("dbo.ServerDatabases", "PrimaryDBAId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServerDatabases", "PrimaryDBAId");
            RenameIndex(table: "dbo.ServerDatabases", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            RenameColumn(table: "dbo.ServerDatabases", name: "Employee_EmployeeId", newName: "EmployeeId");
        }
    }
}
