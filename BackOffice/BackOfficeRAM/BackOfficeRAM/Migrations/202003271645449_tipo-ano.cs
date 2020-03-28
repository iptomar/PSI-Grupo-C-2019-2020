namespace BackOfficeRAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoano : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PontoInteresses", "Ano", c => c.String());
            DropColumn("dbo.PontoInteresses", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PontoInteresses", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.PontoInteresses", "Ano");
        }
    }
}
