namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servers", "PurchaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servers", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}
