namespace DBAToolV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servers", "Memory", c => c.Int());
            AlterColumn("dbo.Servers", "CpuCore", c => c.Int());
            AlterColumn("dbo.Servers", "CpuSpeed", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servers", "CpuSpeed", c => c.Single(nullable: false));
            AlterColumn("dbo.Servers", "CpuCore", c => c.Int(nullable: false));
            AlterColumn("dbo.Servers", "Memory", c => c.Int(nullable: false));
        }
    }
}
