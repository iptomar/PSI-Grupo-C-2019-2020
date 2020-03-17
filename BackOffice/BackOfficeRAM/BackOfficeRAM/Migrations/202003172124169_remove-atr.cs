namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeatr : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PontoInteresses", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PontoInteresses", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
