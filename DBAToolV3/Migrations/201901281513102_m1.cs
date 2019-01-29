namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Status", newName: "DatabaseStatus");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DatabaseStatus", newName: "Status");
        }
    }
}
