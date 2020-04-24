namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattrvisivelpontos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PontoInteresses", "Visivel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PontoInteresses", "Visivel");
        }
    }
}
